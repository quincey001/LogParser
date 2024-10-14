using System;
namespace Parser.Interfaces
{
	public interface IParser
	{
		void Parse(string filePath);
		void SaveParsedData(string saveFile);
	}
}

