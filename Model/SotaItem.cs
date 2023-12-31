namespace XotaApi2.Models;
public class SotaItem : Models.XotaItem, Models.IXotaItem
{
    public override void FillFromJson(dynamic json_object)
    {
        //TODO: Update ID so that we can more easily remove duplicates
        //      and combine with other Xota types

        double freq = json_object["frequency"];
        double fixedFreq = this.FixFrequency(freq);

        int band = base.GetBandFromFrequency(fixedFreq);
        

        this._id = json_object["activatorCallsign"] + "|" + band.ToString() + "|" + json_object["summitCode"];
        this._source = "SOTA";
        this._band = band;
        this._frequency = freq.ToString();
        this._activatorCallsign = json_object["activatorCallsign"];
        this._activatorName = json_object["activatorName"];
        this._locationCode = json_object["summitCode"];
        this._locationDetails = json_object["summitDetails"];
        this._dateTime = json_object["timeStamp"];
        this._mode = json_object["mode"];
    }

    private double FixFrequency(double frequency){
            if (frequency > 500){
                frequency = frequency / 1000;
            }

            return frequency;
        }
}