namespace XotaApi2.Models
{
    public class XotaItem //: IXotaItem
    {
        private const string constUnknown = "UNKNOWN";
        private const string constNotAvailable = "N/A";
        //Public Properties
        public string? Id { get; set; }
        public string Source { get; set; }
        public int? Band { get; set; }
        public string? Frequency { get; set; }
        public string? LocationDetails { get; set; }
        public string? LocationCode { get; set; }
        public string? ActivatorCallsign { get; set; }
        public DateTime? SpotDateTime { get; set; }

        private string? _activatorName;
        public string? ActivatorName
        {
            get
            {
                if (_activatorName == null) return constNotAvailable;
                return _activatorName;
            }
            set
            {
                _activatorName = value;
            }
        }

        private string? _mode;
        public string? Mode
        {
            get
            {
                if (_mode == null) return constUnknown;
                return _mode;
            }
            set
            {
                _mode = value?.ToUpper();
            }
        }

        public XotaItem(SotaItem sotaItem)
        {
            Source = "SOTA";
            
            (int band, double freq) = GetBandAndFrequency(sotaItem.Frequency, true);
            Band = band;
            Frequency = freq.ToString();

            Id = sotaItem.ActivatorCallsign + "|" + band.ToString() + "|" + sotaItem.SummitCode;

            ActivatorCallsign = sotaItem.ActivatorCallsign;
            ActivatorName = sotaItem.ActivatorName;
            LocationCode = sotaItem.SummitCode;
            LocationDetails = sotaItem.SummitDetails;
            SpotDateTime = sotaItem.SpotTime;
            Mode = sotaItem.Mode;
        }
        public XotaItem(PotaItem potaItem)
        {
            Source = "POTA";

            (int band, double freq) = GetBandAndFrequency(potaItem.Frequency);
            Band = band;
            Frequency = freq.ToString();

            Id = potaItem.ActivatorCallsign + "|" + band.ToString() + "|" + potaItem.Reference;

            ActivatorCallsign = potaItem.ActivatorCallsign ?? constUnknown;
            ActivatorName = constUnknown;
            LocationCode = potaItem.Reference;
            LocationDetails = potaItem.Name + "-" + potaItem.LocationDescription;
            SpotDateTime = potaItem.SpotTime;
            Mode = potaItem.Mode;
        }

        public XotaItem(RadarItem radarItem)
        {
            Source = "RaDAR";

            (int band, double freq) = GetBandAndFrequency(radarItem.Frequency);

            Band = band;
            Frequency = freq.ToString();

            Id = radarItem.ActivatorCallsign + "|" + band.ToString() + "|" + radarItem.Reference;
            
            ActivatorCallsign = radarItem.ActivatorCallsign ?? constUnknown;
            ActivatorName = constUnknown;
            LocationCode = radarItem.Reference;
            //LocationDetails = radarItem.Name + "-" + radarItem.LocationDescription;
            SpotDateTime = radarItem.SpotDateTime;
            Mode = radarItem.Mode;
        }

        private (int, double) GetBandAndFrequency(string frequency, bool fixFrequency = false){

            var band = 0;

            if (double.TryParse(frequency, out var freq))
            {
                if (fixFrequency)
                    freq = SotaFixFrequency(freq);

                band = GetBandFromFrequency(freq);
            }

            return (band, freq);
        }
        private static int GetBandFromFrequency(double freq)
        {
            int band = 0;
            if ((freq >= 1800 && freq <= 2000) ||
                (freq >= 1.8 && freq <= 2.0))
            {
                band = 16000;
            }
            else if ((freq >= 3500 && freq <= 4000) ||
                (freq >= 3.5 && freq <= 4.0))
            {
                band = 8000;
            }
            else if ((freq >= 5300 && freq <= 5500) ||
                (freq >= 5.3 && freq <= 5.5))
            {
                band = 6000;
            }
            else if ((freq >= 700000 && freq <= 730000) || 
                (freq >= 7000 && freq <= 7300) ||
                (freq >= 7.0 && freq <= 7.3)) 
            {
                band = 4000;
            }
            else if ((freq >= 10100 && freq <= 10150) ||
                (freq >= 10.1 && freq <= 10.15))
            {
                band = 3000;
            }
            else if ((freq >= 14000 && freq <= 14350) ||
                (freq >= 14.0 && freq <= 14.35))
            {
                band = 2000;
            }
            else if ((freq >= 18068 && freq <= 18160) ||
                (freq >= 18.068 && freq <= 18.160))
            {
                band = 1700;
            }
            else if ((freq >= 21000 && freq <= 21450) ||
                (freq >= 21.0 && freq <= 21.450))
            {
                band = 1500;
            }
            else if ((freq >= 24890 && freq <= 24990) ||
                (freq >= 24.890 && freq <= 24.990))
            {
                band = 1200;
            }
            else if ((freq >= 28000 && freq <= 29700) ||
                (freq >= 28.0 && freq <= 29.7))
            {
                band = 1000;
            }
            else if ((freq >= 50000 && freq <= 54000) ||
                (freq >= 50.0 && freq <= 54.0))
            {
                band = 600;
            }
            else if ((freq >= 144000 && freq <= 148000) ||
                (freq >= 144.0 && freq <= 148.0))
            {
                band = 200;
            }
            else if ((freq >= 420000 && freq <= 450000) ||
                (freq >= 420.0 && freq <= 450.0))
            {
                band = 70;
            }
            else if ((freq >= 902000 && freq <= 928000) ||
                (freq >= 902.0 && freq <= 928.0))
            {
                band = 33;
            }
            else if ((freq >= 1240000 && freq <= 1300000) ||
                (freq >= 1240.0 && freq <= 1300.0))
            {
                band = 23;
            }

            return band;
        }
        private static double GetFrequencyFromRandomString(string x)
        {
            double freq = 0.0;
            if (x.Contains("23cm", StringComparison.OrdinalIgnoreCase))
            {
                freq = 1240.00;
            }
            else if (x.Contains("33cm", StringComparison.OrdinalIgnoreCase))
            {
                freq = 902.00;
            }
            else if (x.Contains("70cm", StringComparison.OrdinalIgnoreCase))
            {
                freq = 440.00;
            }
            else if (x.Contains("2m", StringComparison.OrdinalIgnoreCase))
            {
                freq = 146.52;
            }
            else if (x.Contains("6m", StringComparison.OrdinalIgnoreCase))
            {
                freq = 50.00;
            }
            else if (x.Contains("10m", StringComparison.OrdinalIgnoreCase))
            {
                freq = 28.00;
            }
            else if (x.Contains("12m", StringComparison.OrdinalIgnoreCase))
            {
                freq = 25.00;
            }
            else if (x.Contains("15m", StringComparison.OrdinalIgnoreCase))
            {
                freq = 21.00;
            }
            else if (x.Contains("17m", StringComparison.OrdinalIgnoreCase))
            {
                freq = 18.10;
            }
            else if (x.Contains("20m", StringComparison.OrdinalIgnoreCase))
            {
                freq = 14.00;
            }
            else if (x.Contains("30m", StringComparison.OrdinalIgnoreCase))
            {
                freq = 10.00;
            }
            else if (x.Contains("40m", StringComparison.OrdinalIgnoreCase))
            {
                freq = 7.00;
            }
            else if (x.Contains("60m", StringComparison.OrdinalIgnoreCase))
            {
                freq = 5.40;
            }
            else if (x.Contains("160m", StringComparison.OrdinalIgnoreCase))
            {
                freq = 1.8;
            }

            return freq;
        }
        private static double SotaFixFrequency(double frequency)
        {
            if (frequency > 500)
            {
                frequency = frequency / 1000;
            }

            return frequency;
        }
    }
}