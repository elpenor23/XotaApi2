namespace XotaApi2.Models;
public class PotaItem : Models.XotaItem, Models.IXotaItem
{
    public override void FillFromJson(dynamic json_object)
    {
        //TODO: Update ID so that we can more easily remove duplicates
        //      and combine with other Xota types
        const string constUnknown = "UNKNOWN";

        double freq = json_object["frequency"];

        int band = base.GetBandFromFrequency(freq);

        this._id = json_object["activator"] + "|" + band.ToString() + "|" + json_object["reference"];
        this._source = "POTA";
        this._band = band;
        this._frequency = freq.ToString();
        
        string activatorCallsign = constUnknown;
        if (json_object["activator"] != null) {
            activatorCallsign = json_object["activator"];
        }

        this._activatorCallsign = activatorCallsign;
        this._activatorName = constUnknown;
        this._locationCode = json_object["reference"];
        this._locationDetails = json_object["name"] + " - " + json_object["locationDesc"];
        this._dateTime = json_object["spotTime"];
        this._mode = json_object["mode"];

    }
}