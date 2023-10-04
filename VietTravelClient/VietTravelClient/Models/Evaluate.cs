using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VietTravelClient.Models
{
	public class Evaluate
	{
		public long Id { get; set; }
		public int NumberOfEvaluate { get; set; }
		public float MediumStar { get; set; }
		public Tour Tour { get; set; }
    }
}
