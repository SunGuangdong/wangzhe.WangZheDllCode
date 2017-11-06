using Assets.Scripts.Common;
using System;
using tsf4g_tdr_csharp;

namespace CSProtocol
{
	public class COMDT_TRANSACTION_MSG_OF_IDIPBANTIMEREQ : ProtocolObject
	{
		public ulong ullUid;

		public uint dwLogicWordID;

		public byte bBanTypeNum;

		public ushort[] BanType;

		public byte bChgTimeNum;

		public uint[] ChgTime;

		public static readonly uint BASEVERSION = 1u;

		public static readonly uint CURRVERSION = 1u;

		public static readonly int CLASS_ID = 666;

		public COMDT_TRANSACTION_MSG_OF_IDIPBANTIMEREQ()
		{
			this.BanType = new ushort[100];
			this.ChgTime = new uint[100];
		}

		public override TdrError.ErrorType construct()
		{
			return TdrError.ErrorType.TDR_NO_ERROR;
		}

		public TdrError.ErrorType pack(ref byte[] buffer, int size, ref int usedSize, uint cutVer)
		{
			if (buffer == null || buffer.GetLength(0) == 0 || size > buffer.GetLength(0))
			{
				return TdrError.ErrorType.TDR_ERR_INVALID_BUFFER_PARAMETER;
			}
			TdrWriteBuf tdrWriteBuf = ClassObjPool<TdrWriteBuf>.Get();
			tdrWriteBuf.set(ref buffer, size);
			TdrError.ErrorType errorType = this.pack(ref tdrWriteBuf, cutVer);
			if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
			{
				buffer = tdrWriteBuf.getBeginPtr();
				usedSize = tdrWriteBuf.getUsedSize();
			}
			tdrWriteBuf.Release();
			return errorType;
		}

		public override TdrError.ErrorType pack(ref TdrWriteBuf destBuf, uint cutVer)
		{
			if (cutVer == 0u || COMDT_TRANSACTION_MSG_OF_IDIPBANTIMEREQ.CURRVERSION < cutVer)
			{
				cutVer = COMDT_TRANSACTION_MSG_OF_IDIPBANTIMEREQ.CURRVERSION;
			}
			if (COMDT_TRANSACTION_MSG_OF_IDIPBANTIMEREQ.BASEVERSION > cutVer)
			{
				return TdrError.ErrorType.TDR_ERR_CUTVER_TOO_SMALL;
			}
			TdrError.ErrorType errorType = destBuf.writeUInt64(this.ullUid);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt32(this.dwLogicWordID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt8(this.bBanTypeNum);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			if (100 < this.bBanTypeNum)
			{
				return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
			}
			if (this.BanType.Length < (int)this.bBanTypeNum)
			{
				return TdrError.ErrorType.TDR_ERR_VAR_ARRAY_CONFLICT;
			}
			for (int i = 0; i < (int)this.bBanTypeNum; i++)
			{
				errorType = destBuf.writeUInt16(this.BanType[i]);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
			errorType = destBuf.writeUInt8(this.bChgTimeNum);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			if (100 < this.bChgTimeNum)
			{
				return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
			}
			if (this.ChgTime.Length < (int)this.bChgTimeNum)
			{
				return TdrError.ErrorType.TDR_ERR_VAR_ARRAY_CONFLICT;
			}
			for (int j = 0; j < (int)this.bChgTimeNum; j++)
			{
				errorType = destBuf.writeUInt32(this.ChgTime[j]);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
			return errorType;
		}

		public TdrError.ErrorType unpack(ref byte[] buffer, int size, ref int usedSize, uint cutVer)
		{
			if (buffer == null || buffer.GetLength(0) == 0 || size > buffer.GetLength(0))
			{
				return TdrError.ErrorType.TDR_ERR_INVALID_BUFFER_PARAMETER;
			}
			TdrReadBuf tdrReadBuf = ClassObjPool<TdrReadBuf>.Get();
			tdrReadBuf.set(ref buffer, size);
			TdrError.ErrorType result = this.unpack(ref tdrReadBuf, cutVer);
			usedSize = tdrReadBuf.getUsedSize();
			tdrReadBuf.Release();
			return result;
		}

		public override TdrError.ErrorType unpack(ref TdrReadBuf srcBuf, uint cutVer)
		{
			if (cutVer == 0u || COMDT_TRANSACTION_MSG_OF_IDIPBANTIMEREQ.CURRVERSION < cutVer)
			{
				cutVer = COMDT_TRANSACTION_MSG_OF_IDIPBANTIMEREQ.CURRVERSION;
			}
			if (COMDT_TRANSACTION_MSG_OF_IDIPBANTIMEREQ.BASEVERSION > cutVer)
			{
				return TdrError.ErrorType.TDR_ERR_CUTVER_TOO_SMALL;
			}
			TdrError.ErrorType errorType = srcBuf.readUInt64(ref this.ullUid);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = srcBuf.readUInt32(ref this.dwLogicWordID);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = srcBuf.readUInt8(ref this.bBanTypeNum);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			if (100 < this.bBanTypeNum)
			{
				return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
			}
			this.BanType = new ushort[(int)this.bBanTypeNum];
			for (int i = 0; i < (int)this.bBanTypeNum; i++)
			{
				errorType = srcBuf.readUInt16(ref this.BanType[i]);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
			errorType = srcBuf.readUInt8(ref this.bChgTimeNum);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			if (100 < this.bChgTimeNum)
			{
				return TdrError.ErrorType.TDR_ERR_REFER_SURPASS_COUNT;
			}
			this.ChgTime = new uint[(int)this.bChgTimeNum];
			for (int j = 0; j < (int)this.bChgTimeNum; j++)
			{
				errorType = srcBuf.readUInt32(ref this.ChgTime[j]);
				if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
				{
					return errorType;
				}
			}
			return errorType;
		}

		public override int GetClassID()
		{
			return COMDT_TRANSACTION_MSG_OF_IDIPBANTIMEREQ.CLASS_ID;
		}

		public override void OnRelease()
		{
			this.ullUid = 0uL;
			this.dwLogicWordID = 0u;
			this.bBanTypeNum = 0;
			this.bChgTimeNum = 0;
		}
	}
}