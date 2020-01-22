using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Ketum.Entity

{
    [Table("MonitorStep")]
    public class KTDMonitorStep
    {
        [Key]
        public Guid MonitorStepId { get; set; }
        public Guid MonitorId { get; set; }
        public KTDMonitorStepTypes Type { get; set; }
        public string Settings { get; set; }

		public KTDSMonitorStepSettingsRequest SettingsAsRequest(){
			return JsonConvert.DeserializeObject<KTDSMonitorStepSettingsRequest>(Settings);
		}
    }

    public enum KTDMonitorStepTypes : short
    {
        Request = 1,
        StatusCode = 2,
        HeaderExists = 3,
        BodyContains = 4,
    }

	public class KTDSMonitorStepSettingsRequest{
		public string Url { get; set; }
	}
}