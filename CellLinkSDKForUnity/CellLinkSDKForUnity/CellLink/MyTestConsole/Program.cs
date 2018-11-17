using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellLink;
using CellLink.DataEncoders;
using CellLink.RPC;
using CellLink.Policy;
using System.Net;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace MyTestConsole
{
    class Program
    {
        static RPCClient m_kRPC;

        static string username = "user";
        static string password = "pwd";
        static string url = "http://127.0.0.1";
        static int iPort = 8201;

        static string ms_strHexERC20Code = "1b4c75615100010404040801000000000000000000000000000002021400000024000000070000002440000064800000000000004740000064c0000000000000478000006400010047c000006440010047000100648001004740010064c00100478001006400020047c001001e008000080000000405000000696e69740004090000007472616e7366657200040d0000007472616e7366657246726f6d000408000000617070726f76650004050000006275726e0004090000006275726e46726f6d00040a000000746f6b656e696e666f00040d00000067657442616c616e63654f66000900000000000000020000000c00000000000005200000000a00000007000000050000000980c080050000000900c181050000000980c18201c00100450000008540020086804201c1c0020005010000064141029c8080018e80000049800084450000008a00000049800086450000004600c3008540030086804301c5000000c600c20149c00001450000008a000000498080871e00800010000000040f00000050657273697374656e74446174610004050000006e616d6500040b000000746f6b656e5f6e616d6500040700000073796d626f6c00040200000024000409000000646563696d616c730003000000000000000003406f400100000000040c000000746f74616c537570706c790004050000006d617468000404000000706f7700030a00000000000000040a00000062616c616e63654f660004040000006d736700040700000073656e64657200040a000000616c6c6f77616e63650000000000200000000300000003000000040000000400000005000000050000000600000006000000070000000800000008000000080000000800000008000000080000000800000008000000080000000900000009000000090000000a0000000a0000000a0000000a0000000a0000000a0000000a0000000b0000000b0000000b0000000c000000010000000e000000696e697469616c537570706c7900090000001f00000000000000000000000e0000001e000000000300083d000000c5000000c640c0010581000017c0c0001600008042410000420180001c41000105010100400100011c81000180000002060180011a4100001600008001c10000c9000100064180011a4100001600008001c10000c90081000581000046018001594001011600008042410000420180001c41000105810000464180014c81800286418001584001031600008042410000420180001c41000106018001464180010c410102460180014d818002c9400100464180014c818002c94081004581000086018001c64180018cc10103570001031600008082410000820180005c4100014601800117c0c00216000080c94041001e00800006000000040f00000050657273697374656e744461746100040a00000062616c616e63654f66000407000000617373657274000300000000000000000409000000746f6e756d6265720000000000003d0000000f0000000f0000001000000010000000100000001000000010000000100000001100000011000000110000001100000013000000130000001300000013000000130000001400000014000000140000001400000014000000150000001500000015000000150000001500000015000000150000001600000016000000160000001600000016000000160000001600000016000000160000001700000017000000170000001800000018000000180000001900000019000000190000001a0000001a0000001a0000001a0000001a0000001a0000001a0000001a0000001a0000001b0000001b0000001b0000001c0000001e00000005000000060000005f66726f6d00000000003c000000040000005f746f00000000003c000000070000005f76616c756500000000003c0000000a00000062616c616e63654f6600020000003c0000001100000070726576696f757342616c616e63657300290000003c0000000000000000000000260000002b000000010200071000000084000000c5000000c640c00100010000400180009c40000285800000c1c00000050100000641400240010000800180009c408002820080009e0000011e0080000400000004040000006d736700040700000073656e6465720004060000007072696e740004090000007472616e73666572000000000010000000280000002800000028000000280000002800000028000000290000002900000029000000290000002900000029000000290000002a0000002a0000002b00000002000000040000005f746f00000000000f000000070000005f76616c756500000000000f000000010000000a0000005f7472616e736665720000000000340000003b000000010300081d000000c5000000c640c001058100004601800185c100008601410346818102594001011600008042410000420180001c4100010601800145c100004601c10286018001c5c10000c601c10386c101038d81000309818102040100004001000080018000c00100011c410002020180001e0100011e00800005000000040f00000050657273697374656e744461746100040a000000616c6c6f77616e63650004070000006173736572740004040000006d736700040700000073656e64657200000000001d00000036000000360000003700000037000000370000003700000037000000370000003700000037000000370000003700000038000000380000003800000038000000380000003800000038000000380000003800000039000000390000003900000039000000390000003a0000003a0000003b00000004000000060000005f66726f6d00000000001c000000040000005f746f00000000001c000000070000005f76616c756500000000001c0000000a000000616c6c6f77616e636500020000001c000000010000000a0000005f7472616e736665720000000000430000004900000000020005120000008500000086404001c5800000c6c0c0010581000006c14002060101011a410000160000800a01000089008101c5800000c6c0c001c6c00001c9400000c2008000de0000011e00800004000000040f00000050657273697374656e744461746100040a000000616c6c6f77616e63650004040000006d736700040700000073656e64657200000000001200000045000000450000004600000046000000460000004600000046000000460000004600000046000000460000004700000047000000470000004700000048000000480000004900000003000000090000005f7370656e646572000000000011000000070000005f76616c75650000000000110000000a000000616c6c6f77616e636500020000001100000000000000000000006100000069000000000100041e00000045000000800000005c80000100008000454000004680c00085c00000c5000100c640c101c6c0800059c0000016000080c2400000c20080009c4000018500010086404101c5000100c640c101c6c08000cd00800149c0000185400000c5400000c680c101cd00800189c00083820080009e0000011e008000070000000409000000746f6e756d62657200040f00000050657273697374656e744461746100040a00000062616c616e63654f660004070000006173736572740004040000006d736700040700000073656e64657200040c000000746f74616c537570706c7900000000001e00000063000000630000006300000063000000640000006400000065000000650000006500000065000000650000006500000065000000650000006500000066000000660000006600000066000000660000006600000066000000670000006700000067000000670000006700000068000000680000006900000002000000070000005f76616c756500000000001d0000000a00000062616c616e63654f6600060000001d0000000000000000000000710000007e000000000200083200000085000000c00080009c800001400000018540000086804001c5400000c6c0c001060100011a4100001600008001010100890001000541010046010001594081001600008042410000420180001c41000105410100460180018581010086c1410346818102594081001600008042410000420180001c410001060100010d41000289000100060180014581010046c1c10286018001c5810100c6c1c10386c101038d4100030981810205410000454100004601c2024d41800209410184020180001e0100011e008000090000000409000000746f6e756d62657200040f00000050657273697374656e744461746100040a00000062616c616e63654f6600040a000000616c6c6f77616e63650003000000000000000004070000006173736572740004040000006d736700040700000073656e64657200040c000000746f74616c537570706c790000000000320000007200000072000000720000007200000073000000730000007400000074000000760000007600000076000000760000007600000078000000780000007800000078000000780000007800000078000000790000007900000079000000790000007900000079000000790000007900000079000000790000007a0000007a0000007a0000007b0000007b0000007b0000007b0000007b0000007b0000007b0000007b0000007b0000007c0000007c0000007c0000007c0000007c0000007d0000007d0000007e00000004000000060000005f66726f6d000000000031000000070000005f76616c75650000000000310000000a00000062616c616e63654f660006000000310000000a000000616c6c6f77616e636500080000003100000000000000000000008000000085000000000000040a0000000500000006404000450000004680c0008500000086c04001c5000000c600c1011e0080021e00800005000000040f00000050657273697374656e74446174610004050000006e616d6500040700000073796d626f6c000409000000646563696d616c7300040c000000746f74616c537570706c7900000000000a00000081000000810000008200000082000000830000008300000084000000840000008400000085000000000000000000000000000000870000008d000000000100060e0000005b40000016400080450000004640c0008580000086c04001c6400001da40000016000080c100010000018000400180011e0180011e0080000500000004040000006d736700040700000073656e64657200040f00000050657273697374656e744461746100040a00000062616c616e63654f6600030000000000000000000000000e000000880000008800000088000000880000008a0000008a0000008b0000008b0000008b0000008b0000008c0000008c0000008c0000008d00000004000000090000005f77686f6164647200000000000d000000050000006164647200040000000d0000000a00000062616c616e63654f6600060000000d0000000800000062616c616e6365000a0000000d00000000000000140000000c000000020000001e0000002b0000002b000000260000003b0000003b00000034000000490000004300000069000000610000007e0000007100000085000000800000008d000000870000008d000000010000000a0000005f7472616e7366657200030000001300000000000000";

        static StandardTransactionPolicy EasyPolicy = new StandardTransactionPolicy()
        {
            MaxTransactionSize = null,
            MaxTxFee = null,
            MinRelayTxFee = null,
            ScriptVerify = ScriptVerify.Standard & ~ScriptVerify.LowS
        };

        static RPCResponse RpcCall(string strCommand, params string[] args)
        {
            RPCResponse kRsp = m_kRPC.SendCommand(strCommand, args);
            if (kRsp == null)
            {
                Console.WriteLine("Execute command error!");
            }
            else
            {
                if (kRsp.Error == null)
                {
                    Console.WriteLine(kRsp.ResultString);
                }
                else
                {
                    Console.WriteLine("Error: " + kRsp.Error.Code + " msg: " + kRsp.Error.Message);
                }
            }
            return kRsp;
        }

        static void GetCoinsFromJoken(JToken jtoken, List<Coin> listCoins)
        {
            if (jtoken != null && jtoken.Type == Newtonsoft.Json.Linq.JTokenType.Array && listCoins != null)
            {
                foreach (var v in jtoken)
                {
                    uint256 fromTxHash = uint256.Parse((string)v["txhash"]);
                    uint fromOutputIndex = uint.Parse((string)v["outn"]);
                    Money amount = Money.Parse((string)v["value"]);
                    Script scriptPubKey = new Script(Encoders.Hex.DecodeData((string)v["script"]));
                    listCoins.Add(new Coin(fromTxHash, fromOutputIndex, amount, scriptPubKey));
                }
            }
        }

        static List<Coin> GetCoinsByAddress(string strAddress)
        {
            List<Coin> listCoins = new List<Coin>();
            RPCResponse kRsp = RpcCall("getaddresscoins", strAddress);
            if (kRsp != null && kRsp.Result != null && kRsp.Result.Type == Newtonsoft.Json.Linq.JTokenType.Array)
            {
                GetCoinsFromJoken(kRsp.Result, listCoins);
            }

            return listCoins;
        }

        static void TestGetCoinsAndMakeTransaction()
        {
            Console.WriteLine("TestGetCoinsAndMakeTransaction");
            //------------------------

            List<Coin> listCoins = GetCoinsByAddress("XD7SstxYNeBCUzLkVre3gP1ipUjJBGTxRB");

            BitcoinSecret bitsecret = new BitcoinSecret("L1amKPbuEpYwqU2uVRb34i2oUAa328RvNaEoKrCqgdEPLgV6MDcz");
            List<Key> keys = new List<Key>();
            keys.Add(bitsecret.PrivateKey);

            BitcoinAddress dest = BitcoinAddress.Create("XD7SstxYNeBCUzLkVre3gP1ipUjJBGTxRB", CellLink.Network.Main);

            var txBuilder = new TransactionBuilder(0);
            txBuilder.StandardTransactionPolicy = EasyPolicy;
            var tx = txBuilder
                .AddCoins(listCoins.ToArray())
                .AddKeys(keys.ToArray())
                .Send(dest, Money.Parse("0.5"))
                .SendFees(Money.Parse("0.0001"))
                .SetChange(dest)
                .BuildTransaction(false);
            tx.Version = 2; // current transaction version
            tx = txBuilder.SignTransactionInPlace(tx);

            TransactionPolicyError[] errors;
            if (txBuilder.Verify(tx, (Money)null, out errors))
            {
                RPCResponse kRsp2 = RpcCall("sendrawtransaction", tx.ToHex()); //m_kRPC.SendCommand(strSendRawTransaction, params2.ToArray());
            }
            else
            {
                string strError = "build transaction verify fail:\n";
                foreach (var err in errors)
                {
                    strError += err.ToString() + "\n";
                }
                Console.WriteLine(strError);
            }
        }

        static void SignAndSendTransaction(JToken txhex, JToken jtCoins, List<Key> keys)
        {
            Transaction tx = Transaction.Parse((string)txhex);

            var txBuilder = new TransactionBuilder(0);
            txBuilder.StandardTransactionPolicy = EasyPolicy;
            txBuilder.AddKeys(keys.ToArray());

            if (jtCoins != null)
            {
                List<Coin> txCoins = new List<Coin>();
                GetCoinsFromJoken(jtCoins, txCoins);
                txBuilder.AddCoins(txCoins);
            }

            tx = txBuilder.SignTransactionInPlace(tx);

            Transaction ntx = new Transaction(tx.ToBytes());
            Debug.Assert(tx.GetHash() == ntx.GetHash());

            TransactionPolicyError[] errors;
            if (txBuilder.Verify(tx, (Money)null, out errors))
            {
                RPCResponse kRsp2 = RpcCall("sendrawtransaction", tx.ToHex()); //m_kRPC.SendCommand(strSendRawTransaction, params2.ToArray());
            }
            else
            {
                string strError = "build transaction verify fail:\n";
                foreach (var err in errors)
                {
                    strError += err.ToString() + "\n";
                }
                Console.WriteLine(strError);
            }
        }

        static void TestPremakeTransaciton()
        {
            Console.WriteLine("TestPublishContract");

            string fromaddress = "XD7SstxYNeBCUzLkVre3gP1ipUjJBGTxRB"; //从那个地址转币出去
            string toaddress = "XD7SstxYNeBCUzLkVre3gP1ipUjJBGTxRB"; //转到哪里去
            string changeaddress = "XD7SstxYNeBCUzLkVre3gP1ipUjJBGTxRB";//找零地址
            string amount = "0.48966140";//数目
            string fee = "0.0001";//费率，暂时没什么用
            RPCResponse kRsp = RpcCall("premaketransaction", fromaddress, toaddress, changeaddress, amount, fee);
            if (kRsp != null && kRsp.Result != null)
            {
                //private keys
                List<Key> keys = new List<Key>();
                BitcoinSecret bitsecret = new BitcoinSecret("L1amKPbuEpYwqU2uVRb34i2oUAa328RvNaEoKrCqgdEPLgV6MDcz");
                keys.Add(bitsecret.PrivateKey);

                SignAndSendTransaction(kRsp.Result["txhex"], kRsp.Result["coins"], keys);
            }
        }

        static void TestPublishContract()
        {
            Console.WriteLine("TestPublishContract");

            string fromaddress = "XD7SstxYNeBCUzLkVre3gP1ipUjJBGTxRB";//费用支出地址
            string senderpubkeyhex = "02eaf227d7c4b38fd8798d82d00081d5f7833f5e3a690a5ec72103ac37ae0db877"; //公约地址hex format,
            string amount = "0.1313";//发送给智能合约的金额
            string changeaddress = "XD7SstxYNeBCUzLkVre3gP1ipUjJBGTxRB";//找零地址
            
            RPCResponse kRsp = RpcCall("prepublishcode", ms_strHexERC20Code, fromaddress, senderpubkeyhex, amount, changeaddress);
            if (kRsp != null && kRsp.Result != null)
            {
                //private keys
                List<Key> keys = new List<Key>();
                BitcoinSecret bitsecret = new BitcoinSecret("L1amKPbuEpYwqU2uVRb34i2oUAa328RvNaEoKrCqgdEPLgV6MDcz");
                keys.Add(bitsecret.PrivateKey);

                Transaction tx = Transaction.Parse((string)kRsp.Result["txhex"]);
                Console.WriteLine("txid", tx.GetHash());
                Console.WriteLine("contractaddress", tx.ContractAddress);

                SignAndSendTransaction(kRsp.Result["txhex"], kRsp.Result["coins"], keys);
            }
        }
        //XD7SstxYNeBCUzLkVre3gP1ipUjJBGTxRB 02eaf227d7c4b38fd8798d82d00081d5f7833f5e3a690a5ec72103ac37ae0db877 L1amKPbuEpYwqU2uVRb34i2oUAa328RvNaEoKrCqgdEPLgV6MDcz
        static void TestCallContract()
        {
            Console.WriteLine("TestCallContract");

            string contractaddress = "XBShZ1JVmkJymKfKC4CNdFzpKYGu6emve6";// 智能合约地址
            string fundaddress = "XD7SstxYNeBCUzLkVre3gP1ipUjJBGTxRB";// 我的币地址
            string amount = "0.01"; // 转给智能合约的币
            string senderpubkeyhex = "02eaf227d7c4b38fd8798d82d00081d5f7833f5e3a690a5ec72103ac37ae0db877";//作为sender的公钥的pubkey的hex
            senderpubkeyhex = "03654aa6a4ec9e56f6058777caf80c481e4eecda33eccecd90d58f103c21f13a64";
            string changeaddress = "XD7SstxYNeBCUzLkVre3gP1ipUjJBGTxRB";//找零地址
            string issendcall = "1"; //是否要构造交易，1是，0否

            string funcname = "withdraw"; //要调用的智能合约的函数名称
            string param1 = "XWaZ5vKP3Rs5z4CzskGWBjEEJp1QyNdYoE"; //参数  
            string param2 = "3"; //参数  
            string param3 = "3000"; //参数  

            RPCResponse kRsp = RpcCall("precallcontract", contractaddress, fundaddress, amount, senderpubkeyhex, changeaddress, issendcall, funcname, param1, param2, param3);
            //RPCResponse kRsp = RpcCall("precallcontract", contractaddress, fundaddress, amount, senderpubkeyhex, changeaddress, issendcall, funcname, param1, param2, tokenamunt);
            if (kRsp != null && kRsp.Result != null)
            {
                Console.WriteLine("contract return value:" + kRsp.Result["call_return"] == null? "null": kRsp.Result["call_return"].ToString());
                if (kRsp.Result["txhex"] != null && kRsp.Result["coins"] != null)
                {
                    //private keys 添加 fundaddress和sender 的私钥, (unique)
                    List<Key> keys = new List<Key>();
                    BitcoinSecret bitsecret = new BitcoinSecret("L1amKPbuEpYwqU2uVRb34i2oUAa328RvNaEoKrCqgdEPLgV6MDcz"); //XD7SstxYNeBCUzLkVre3gP1ipUjJBGTxRB
                    keys.Add(bitsecret.PrivateKey);

                    BitcoinSecret bitsecret2 = new BitcoinSecret("KyXNPMDnVYz9QnFBFpxDGzKeVfkb3xitxrKxrpSjm7LMGMhgc3Ym"); //XD7SstxYNeBCUzLkVre3gP1ipUjJBGTxRB
                    keys.Add(bitsecret2.PrivateKey);

                    SignAndSendTransaction(kRsp.Result["txhex"], kRsp.Result["coins"], keys);
                }
                else
                {
                    Console.WriteLine("智能合约数据没修过，没交易提交");
                }
            }
        }

        static void test()
        {
            List<Key> keys = new List<Key>();
            BitcoinSecret bitsecret = new BitcoinSecret("L1amKPbuEpYwqU2uVRb34i2oUAa328RvNaEoKrCqgdEPLgV6MDcz"); //XD7SstxYNeBCUzLkVre3gP1ipUjJBGTxRB
            keys.Add(bitsecret.PrivateKey);

            BitcoinSecret bitsecret2 = new BitcoinSecret("KyXNPMDnVYz9QnFBFpxDGzKeVfkb3xitxrKxrpSjm7LMGMhgc3Ym"); //XD7SstxYNeBCUzLkVre3gP1ipUjJBGTxRB
            keys.Add(bitsecret2.PrivateKey);
            JToken jt = JToken.Parse("{\"call_return\": [0],\"txhex\": \"04000000013d2bc79d4d93797a8291a650f4709d6c11422f28d5752433032b265d9e412d910000000000feffffff0240420f000000000016c11401085f21818b3689ab5a6129f68dddcb0fd791791a92d17c9e0000001976a9141354786ccbc4f52ccded0a6da3beb2b1c993822f88ac0000000001085f21818b3689ab5a6129f68dddcb0fd791792103654aa6a4ec9e56f6058777caf80c481e4eecda33eccecd90d58f103c21f13a64087265636861726765315b225857615a35764b50335273357a34437a736b4757426a45454a703151794e64596f45222c2233222c2233303030225d0000000000\",\"coins\": [{\"txhash\": \"912d419e5d262b03332475d5282f42116c9d70f450a691827a79934d9dc72b3d\",\"outn\": 0,\"value\": 6806.99948151,\"script\": \"76a9141354786ccbc4f52ccded0a6da3beb2b1c993822f88ac\"}]}");
            SignAndSendTransaction(jt["txhex"], jt["coins"], keys);

        }

        static void Main(string[] args)
        {
            Network kNet = Network.Main;

            ExtKey kEK = new ExtKey();
            string strMK = kEK.ToString(kNet);

            ExtKey kEK2 = ExtKey.Parse(strMK, kNet);

            NetworkCredential creds = new NetworkCredential
            {
                UserName = username,
                Password = password
            };

            string strAddress = url + ":" + iPort.ToString();
            try
            {
                m_kRPC = new RPCClient(creds, new Uri(strAddress), Network.Main);

                //    TestGetCoinsAndMakeTransaction();
                //    TestPremakeTransaciton();
                //    TestPublishContract();

                TestCallContract();

                //test();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Finsh, press any key to exit"); 
            Console.ReadKey();
        }
    }
}
