using System;
using System.ComponentModel.DataAnnotations;

namespace OV.Entitites
{
	public interface IEntity
	{
		Guid Id { get; set; }
	}
}