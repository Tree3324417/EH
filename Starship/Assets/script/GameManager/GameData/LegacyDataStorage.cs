using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace GameModel.GameData 
{
	public static class LegacyDataStorage
	{
		public enum GameDataType
		{
			Game = 0,
			StarMap = 1,
			Player = 2,
			Shop = 3,
			Events = 4,
			Boss = 5,
			Region = 6,
			Purchases = 7,
			Wormhole = 8,
			Achievement = 9,
			Laboratory = 10,
			Research = 11,
			Craft = 12,
			Resources = 13,
			Upgrades = 14,
		}

		private const string GameFileName = "a0ea0e78-f341-4ce2-9474-b52cc2fd366b";
		private const string StarMapFileName = "fe41605a-8bef-44ce-9f1d-5aa58fd61110";
		private const string PlayerFileName = "6b883a8f-08d9-452f-99ea-d620b24508e6";
		private const string ShopFileName = "86824bb9-5237-4b40-9c39-4ad1e9b98b21";
		private const string EventFileName = "20de5a7d-d36e-4b0f-b31a-3ab4620d6a88";
		private const string BossFileName = "4e5db80b-986e-40d3-829e-fd22c2f93e49";
		private const string RegionFileName = "a9834976-d73f-44ae-aff9-356715463c8e";
		private const string PurchasesFileName = "244a72dd-9d03-4901-bf03-03f84b32a503";
		private const string WormholeFileName = "c414775b-8989-43d3-8364-469148c68362";
		private const string AchievementFileName = "ccdc1e85-5aa1-414e-9525-748307a9785d";
		private const string LaboratoryFileName = "630519d8-ca16-4806-88f6-7d2643ad6402";
		private const string ResearchFileName = "fcab81e7-37a0-4e0a-a571-4086e3d9f815";
		private const string CraftFileName = "32c53da3-7bda-495c-a2a7-222f38a93889";
		private const string ResourcesFileName = "fe0331bc-ec9e-4184-95fd-10027a10bf76";
		private const string UpgradesFileName = "641aadb5-d561-41fd-bcb1-40e0c5c03334";

		private static string GetFileName(GameDataType id)
		{
			switch (id)
			{
			case GameDataType.Game:
				return GameFileName;
			case GameDataType.StarMap:
				return StarMapFileName;
			case GameDataType.Player:
				return PlayerFileName;
			case GameDataType.Shop:
				return ShopFileName;
			case GameDataType.Events:
				return EventFileName;
			case GameDataType.Boss:
				return BossFileName;
			case GameDataType.Region:
				return RegionFileName;
			case GameDataType.Purchases:
				return PurchasesFileName;
			case GameDataType.Wormhole:
				return WormholeFileName;
			case GameDataType.Achievement:
				return AchievementFileName;
			case GameDataType.Laboratory:
				return LaboratoryFileName;
			case GameDataType.Research:
				return ResearchFileName;
			case GameDataType.Craft:
				return CraftFileName;
			case GameDataType.Resources:
				return ResourcesFileName;
			case GameDataType.Upgrades:
				return UpgradesFileName;
			default:
				return string.Empty;
			}
		}

		private static uint random(ref uint w, ref uint z)
		{
			z = 36969 * (z & 65535) + (z >> 16);
			w = 18000 * (w & 65535) + (w >> 16);
			return (z << 16) + w;  /* 32-bit result */
		}

		public static byte[] ReadData(GameDataType type, bool readFromBackup = false)
		{
			var fileName = GetFileName(type);
			try
			{
				var data = File.ReadAllBytes(Application.persistentDataPath + "/" + fileName);
				var hasCheckSumm = data[0] == 0xfe;
				if (data[0] == 0xff || data[0] == 0xfe)
				{
					uint size = (uint)(data.Length - sizeof(uint) - (hasCheckSumm ? sizeof(byte) : 0));
					uint w = 0x12345678 ^ size;
					uint z = 0x87654321 ^ size;
					byte check = 0;
					for (int i = sizeof(int); i < size + sizeof(int); ++i)
					{
						data[i] ^= (byte)random(ref w,ref z);
						check += data[i];
					}
					check ^= (byte)random(ref w,ref z);
					if (hasCheckSumm && check != data[data.Length-1])
					{
						UnityEngine.Debug.Log("CheckSumm error: " + check + " " + data[data.Length-1]);
					}
					
					return data.Skip(sizeof(int)).Take((int)size).ToArray();
				}
				
				return data;
			}
			catch (System.Exception e)
			{
				UnityEngine.Debug.Log(e.Message);
				return null;
			}
		}
		
//		public static void WriteData(GameDataType type, byte[] data)
//		{
//			try
//			{
//				var fileName = GetFileName(type);
//				var fullName = Application.persistentDataPath + "/" + fileName;
//
//				if (data == null || data.Length == 0)
//				{
//					File.Delete(fullName);
//					return;
//				}
//
//				var encrypted = new List<byte>();
//				encrypted.Add(0xfe);
//				encrypted.Add(0xff);
//				encrypted.Add(0xff);
//				encrypted.Add(0xff);
//
//				var size = (uint)data.Length;
//				byte check = 0;
//				uint w = 0x12345678 ^ size;
//				uint z = 0x87654321 ^ size;
//				for (int i = 0; i < size; ++i)
//				{
//					check += data[i];
//					encrypted.Add((byte)(data[i] ^ (byte)random(ref w,ref z)));
//				}
//
//				encrypted.Add((byte)(check ^ (byte)random(ref w,ref z)));
//				File.WriteAllBytes(fullName, encrypted.ToArray());
//			}
//			catch (System.Exception e)
//			{
//				UnityEngine.Debug.Log(e.Message);
//			}
//		}
	}
}
