
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

function test1()
{
	var rpcRet = {
	  "call_return": [
		true
	  ],
	  "txhex": "040000000286c8876620cbb297f2b910a6191ddb4d7f04a8f0168d3b04bedf0a873060cccb0100000000feffffff8d29dd746c320da10fb2011760b4dbb787cb731badf8a7660b525fa11b22f6e00000000000ffffffff0440420f000000000016c11401085f21818b3689ab5a6129f68dddcb0fd79179f482a37c9e0000001976a9141354786ccbc4f52ccded0a6da3beb2b1c993822f88ac48d5f5050000000016c11401085f21818b3689ab5a6129f68dddcb0fd79179b80b0000000000001976a914d2ef0573aba3ee7d175e9db04b802cbf1023dd6b88ac1800000001085f21818b3689ab5a6129f68dddcb0fd791792103654aa6a4ec9e56f6058777caf80c481e4eecda33eccecd90d58f103c21f13a64087769746864726177315b225857615a35764b50335273357a34437a736b4757426a45454a703151794e64596f45222c2233222c2233303030225d0000000000",
	  "coins": [
		{
		  "txhash": "cbcc6030870adfbe043b8d16f0a8047f4ddb1d19a610b9f297b2cb206687c886",
		  "outn": 1,
		  "value": 6806.96929622,
		  "script": "76a9141354786ccbc4f52ccded0a6da3beb2b1c993822f88ac"
		},
		{
		  "txhash": "e0f6221ba15f520b66a7f8ad1b73cb87b7dbb4601701b20fa10d326c74dd298d",
		  "outn": 0,
		  "value": 1.0,
		  "script": "c11401085f21818b3689ab5a6129f68dddcb0fd79179"
		}
	  ]
	}

	var inprikeys = ["L1amKPbuEpYwqU2uVRb34i2oUAa328RvNaEoKrCqgdEPLgV6MDcz", "KyXNPMDnVYz9QnFBFpxDGzKeVfkb3xitxrKxrpSjm7LMGMhgc3Ym"];
	//inprikeys=[];
	signcontract(rpcRet, inprikeys);
}

function test2()
{
	/*
privkey	L4crCjgXNNVLt1W2JVwp9SNemJKR8wvSvZNv9KAjjA2rNFrJprjp

pubkey 038fef9e61cd492075c1347f2768d53413fd39de2e7ad6b427249e87e1f788b7d0

pubkeyhash XJALRgjny6mGyFsYAiLao26BjfesPJtq1Y
	*/
	
	var rpcRet = {
	  "call_return": [
		0
	  ],
	  "txhex": "040000000175043f41f7e6fe3997c1059ca576bcea37a850dcf4cca3f2093995cd0de76bf10000000000feffffff0240420f000000000016c11401085f21818b3689ab5a6129f68dddcb0fd791794f8dfc53020000001976a9144ab8f6207008243eeaa90e232d99b09af29c091888ac1c00000001085f21818b3689ab5a6129f68dddcb0fd7917921038fef9e61cd492075c1347f2768d53413fd39de2e7ad6b427249e87e1f788b7d0087265636861726765025b5d0000000000",
	  "coins": [
		{
		  "txhash": "f16be70dcd953909f2a3ccf4dc50a837eabc76a59c05c19739fee6f7413f0475",
		  "outn": 0,
		  "value": 100.00000000,
		  "script": "76a9144ab8f6207008243eeaa90e232d99b09af29c091888ac"
		}
	  ]
	}
	
	var inprikeys = ["L4crCjgXNNVLt1W2JVwp9SNemJKR8wvSvZNv9KAjjA2rNFrJprjp"];
	
	signcontract(rpcRet, inprikeys);
	
	console.log(.00000003 * 100000000); //error
	console.log(Unit.fromBTC(3e-8)._value);
	console.log(Unit.fromBTC(.00000003)._value);
	console.log(Unit.fromBTC('.00000003')._value);
}
test2();

