﻿namespace RealEstate_Dapper_Api.Dtos.SubFeatureDtos
{
    public class UpdateSubFeatureDto
    {
        public int SubFeatureID { get; set; }
        public string Icon { get; set; }
        public string TopTitle { get; set; }
        public string MainTitle { get; set; }
        public string Description { get; set; }
        public string SubTitle { get; set; }
    }
}