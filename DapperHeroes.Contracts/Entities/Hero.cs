using System;
using System.ComponentModel.DataAnnotations;

namespace DapperHeroes.Contracts.Entities
{
	public class Hero
	{
		[Key]
		public long Id { get; set; }
		
		[Required]
		[MaxLength(150)]
		public string Name { get; set; }
		public string Powers { get; set; }
		public bool HasCape { get; set; }
		public DateTime Created { get; set; }
		public bool IsAlive { get; set; }
		public Category Category { get; set; }
	}

	public enum Category
	{
		Anime,
		Comic,
		History,
		Mythology
	}
}
