
namespace XotaApi2.Models
{
    public class XotaItem : IXotaItem
    {
        public XotaItem(){
            //empty constructor
        }

        //Public Properties
        public string? Id => _id;
        public string? Source => _source;
        public int? Band => _band;
        public string? Frequency => _frequency;
        public string? LocationDetails => _locationDetails;
        public string? LocationCode => _locationCode;
        public string ActivatorName 
        { 
            get 
            {
                if (_activatorName == null) return "N/A";
                return _activatorName; 
            }
        }
        public string? ActivatorCallsign => _activatorCallsign;
        public DateTime? DateTime => _dateTime;
        public string? Mode
        {
            get
            {
                if (_mode == null) return "UNKNOWN";
                return _mode.ToUpper();
            }
        }
        public virtual void FillFromJson(dynamic json)
        {
            throw new NotImplementedException();
        }

        //Protected
        protected string? _id;
        protected string? _source;
        protected int? _band;
        protected string? _frequency;
        protected string? _locationDetails;
        protected string? _locationCode;
        protected string? _activatorName;
        protected string? _activatorCallsign;
        protected DateTime? _dateTime;
        protected string? _mode;
        protected int GetBandFromFrequency(double freq){
            int band = 0;
            if ((freq >= 1800 && freq <= 2000) ||
                (freq >= 1.8 && freq <= 2.0))
            {
                band = 16000;
            } else if ((freq >= 3500 && freq <= 4000) ||
                (freq >= 3.5 && freq <= 4.0))
            {
                band = 8000;
            } else if ((freq >= 5300 && freq <= 5500) ||
                (freq >= 5.3 && freq <= 5.5))
            {
                band = 6000;
            } else if ((freq >= 7000 && freq <= 7300) ||
                (freq >= 7.0 && freq <= 7.3))
            {
                band = 4000;
            } else if ((freq >= 10100 && freq <= 10150) ||
                (freq >= 10.1 && freq <= 10.15))
            {
                band = 3000;
            } else if ((freq >= 14000 && freq <= 14350) ||
                (freq >= 14.0 && freq <= 14.35))
            {
                band = 2000;
            } else if ((freq >= 18068 && freq <= 18160) ||
                (freq >= 18.068 && freq <= 18.160))
            {
                band = 1700;
            } else if ((freq >= 21000 && freq <= 21450) ||
                (freq >= 21.0 && freq <= 21.450))
            {
                band = 1500;
            } else if ((freq >= 24890 && freq <= 24990) ||
                (freq >= 24.890 && freq <= 24.990))
            {
                band = 1200;
            } else if ((freq >= 28000 && freq <= 29700) ||
                (freq >= 28.0 && freq <= 29.7))
            {
                band = 1000;
            } else if ((freq >= 50000 && freq <= 54000) ||
                (freq >= 50.0 && freq <= 54.0))
            {
                band = 600;
            } else if ((freq >= 144000 && freq <= 148000) ||
                (freq >= 144.0 && freq <= 148.0))
            {
                band = 200;
            } else if ((freq >= 420000 && freq <= 450000) ||
                (freq >= 420.0 && freq <= 450.0))
            {
                band = 70;
            } else if ((freq >= 902000 && freq <= 928000) ||
                (freq >= 902.0 && freq <= 928.0))
            {
                band = 33;
            } else if ((freq >= 1240000 && freq <= 1300000) ||
                (freq >= 1240.0 && freq <= 1300.0))
            {
                band = 23;
            }

            return band;
        }
        protected double GetFrequencyFromRandomString(string x){
            double freq = 0.0;
            if(x.ToLower().Contains("23cm")){
                freq = 1240.00;
            } else if(x.ToLower().Contains("33cm")){
                freq = 902.00;
            } else if(x.ToLower().Contains("70cm")){
                freq = 440.00;
            } else if(x.ToLower().Contains("2m")){
                freq = 146.52;
            } else if(x.ToLower().Contains("6m")){
                freq = 50.00;
            } else if(x.ToLower().Contains("10m")){
                freq = 28.00;
            } else if(x.ToLower().Contains("12m")){
                freq = 25.00;
            } else if(x.ToLower().Contains("15m")){
                freq = 21.00;
            } else if(x.ToLower().Contains("17m")){
                freq = 18.10;
            } else if(x.ToLower().Contains("20m")){
                freq = 14.00;
            } else if(x.ToLower().Contains("30m")){
                freq = 10.00;
            } else if(x.ToLower().Contains("40m")){
                freq = 7.00;
            } else if(x.ToLower().Contains("60m")){
                freq = 5.40;
            } else if(x.ToLower().Contains("160m")){
                freq = 1.8;
            }

            return freq;
        }
    }
}