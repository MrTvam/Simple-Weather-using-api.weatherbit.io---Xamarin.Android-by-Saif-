using System.Collections.Generic;

namespace Simple_Weather
{
    public class Weather
    {
        public string icon { get; set; }
        public int code { get; set; }
        public string description { get; set; }
    }

    public class WData
    {
        public double rh { get; set; }
        public string pod { get; set; }
        public double lon { get; set; }
        public int pres { get; set; }
        public string timezone { get; set; }
        public string ob_time { get; set; }
        public string country_code { get; set; }
        public int clouds { get; set; }
        public int ts { get; set; }
        public int solar_rad { get; set; }
        public string state_code { get; set; }
        public string city_name { get; set; }
        public double wind_spd { get; set; }
        public string wind_cdir_full { get; set; }
        public string wind_cdir { get; set; }
        public double slp { get; set; }
        public int vis { get; set; }
        public int h_angle { get; set; }
        public string sunset { get; set; }
        public int dni { get; set; }
        public double dewpt { get; set; }
        public int snow { get; set; }
        public int uv { get; set; }
        public int precip { get; set; }
        public int wind_dir { get; set; }
        public string sunrise { get; set; }
        public int ghi { get; set; }
        public int dhi { get; set; }
        public int aqi { get; set; }
        public double lat { get; set; }
        public Weather weather { get; set; }
        public string datetime { get; set; }
        public double temp { get; set; }
        public string station { get; set; }
        public double elev_angle { get; set; }
        public int app_temp { get; set; }
    }

    public class Root
    {
        public List<WData> data { get; set; }
        public int count { get; set; }
    }




}