/*

智能合约调用测试，F12打开chrome控制台
    1、通过RPC接口 precallcontract 获取JSON格式的返回值，如下面 txhex: testcallcontract 中的var rpcRet。
	2、如函数 testcallcontract 签名
	3、通过rpc sendrawtransaction 把签名后的交易的hexstring，即var txsignedhex = kTras.toString();的值发送magnachain节点,
*/
function signcontract(rpcRet, inprikeys)
{
	/*
	var prikeys = new Array();
	if (_.isArray(inprikeys))
    {
        _.each(inprikeys, function (pk)
        {
            prikeys.push(new PrivateKey(pk));
        });
    }
	else
	{
		prikeys.push(new PrivateKey(inprikeys));
	}
	*/
	var kTras = new Transaction(rpcRet.txhex);
	kTras.setOutputsFromCoins(rpcRet.coins);
	
	//kTras.sign(prikeys);
	kTras.sign(inprikeys);
	
	var txsignedhex = kTras.toString();
	console.log("txhex: "+txsignedhex);
	
	kTras.verify();
	kTras.isFullySigned();
	return txsignedhex;
}

function testcallcontract()
{
	/*
privkey	L3NaEWWcxmefNU8vccDf2f6Gjd9iEDaZX9BNhsrCgwyFA4SfR4aB

pubkey 0231f3dd2b894480d388dae87e061d31bb848584f4802c3226fd3dcab9bf11674c

pubkeyhash XQRLvExkE3gnKcrfhdtfY8DW2nxtBQVEw4
	*/
	
	var rpcRet ={
  "return": [
    true
  ],
  "txhex": "0400000001069e7c2dd421c444395788326613355d9cb35fab5c039385fb457fac75767d137b00000000feffffff0238310a99e80000001976a9148f605dd5de02a198af15746f33f7bcd83209b45088ac00ca9a3b0000000016c1141c54d97609ac16ff372027480dc8f5a2e49cba71140000001c54d97609ac16ff372027480dc8f5a2e49cba71210231f3dd2b894480d388dae87e061d31bb848584f4802c3226fd3dcab9bf11674c046275726e055b2231225d000000000000000000",
  "coins": [
    {
      "txhash": "137d7675ac7f45fb8593035cab5fb39c5d3513663288573944c421d42d7c9e06",
      "outn": 123,
      "value": 10000.00000000,
      "script": "76a9148f605dd5de02a198af15746f33f7bcd83209b45088ac"
    }
  ]
}

	var inprikeys = ["L3NaEWWcxmefNU8vccDf2f6Gjd9iEDaZX9BNhsrCgwyFA4SfR4aB"];
	
	signcontract(rpcRet, inprikeys);
}
testcallcontract();

