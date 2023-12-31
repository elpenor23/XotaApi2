using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using NuGet.Configuration;

namespace XotaApi2.model;

public class RadarItem : Models.XotaItem, Models.IXotaItem
{
    public override void FillFromJson(dynamic json_object)
    { 
        //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(json_object));
        const string constUnknown = "UNKNOWN";
        double freq;
        if(!double.TryParse(json_object["Frequency"].ToString(), out freq))
            freq = GetFrequencyFromRandomString(json_object["Frequency"].ToString());

        int band = base.GetBandFromFrequency(freq);

        //Yeah this is going to need work to fit into everything
        this._id = json_object["Callsign"] + "|" + band.ToString() + "|" + json_object["id"];
        this._source = "RaDAR";
        this._band = band;
        this._frequency = freq.ToString();

        this._activatorCallsign = json_object["Callsign"];
        this._activatorName = constUnknown;
        this._locationCode = constUnknown;
        this._locationDetails = constUnknown;

        var x = System.DateTime.Now;
        string strDateTime = json_object["myDate"] + " " + json_object["myTime"];
        Console.WriteLine(strDateTime);
        var test = System.DateTime.TryParse(strDateTime, out x);
        this._dateTime = x;
        this._mode = json_object["Mode"];
    }
}
