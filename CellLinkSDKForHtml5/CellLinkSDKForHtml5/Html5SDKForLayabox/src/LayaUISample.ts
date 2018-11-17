import test = ui.test.TestPageUI;
import Label = Laya.Label;
import Handler = Laya.Handler;
import Loader = Laya.Loader;

import Networks = celllink.Networks;
import PrivateKey = celllink.PrivateKey;
import PublicKey = celllink.PublicKey;
import Address = celllink.Address;
import HDPrivateKey = celllink.HDPrivateKey;
import kHDPubKey = celllink.HDPublicKey;
import Transaction = celllink.Transaction;
import Output = celllink.Output;

//declare var celllink;
//declare var jsSHA;
//declare var Buffer;

class TestUI extends ui.test.TestPageUI
{
	constructor()
	{
		super();
		//btn是编辑器界面设定的，代码里面能直接使用，并且有代码提示
		this.btn.on(Laya.Event.CLICK, this, this.onBtnClick);
		this.btn2.on(Laya.Event.CLICK, this, this.onBtn2Click);

		var strHex : string = "04000000013d2bc79d4d93797a8291a650f4709d6c11422f28d5752433032b265d9e412d910000000000feffffff0240420f000000000016c11401085f21818b3689ab5a6129f68dddcb0fd791791a92d17c9e0000001976a9141354786ccbc4f52ccded0a6da3beb2b1c993822f88ac0000000001085f21818b3689ab5a6129f68dddcb0fd791792103654aa6a4ec9e56f6058777caf80c481e4eecda33eccecd90d58f103c21f13a64087265636861726765315b225857615a35764b50335273357a34437a736b4757426a45454a703151794e64596f45222c2233222c2233303030225d0000000000";
		var kTras : Transaction = new Transaction(strHex);

		// console.log(kTras.contractAdd);
		// //console.log(kTras.contractCode);
		// console.log(kTras.contractFun);
		// console.log(kTras.contractParams);
		// console.log(kTras.contractSender.toString());

		var out = 
		{
			"satoshis": 680699948151,
			"script": "76a9141354786ccbc4f52ccded0a6da3beb2b1c993822f88ac"		
		};

		//console.log(kTras.inputs[0].toObject());
		//console.log(kTras.outputs[0].toObject());

		var kOut : Output = new Output(out);

		kTras.inputs[0].setOutput(kOut);

		var kPriKey1 : PrivateKey = new PrivateKey("L1amKPbuEpYwqU2uVRb34i2oUAa328RvNaEoKrCqgdEPLgV6MDcz", Networks.livenet);
		kTras.sign(kPriKey1);

		 var kPriKey2 : PrivateKey = new PrivateKey("KyXNPMDnVYz9QnFBFpxDGzKeVfkb3xitxrKxrpSjm7LMGMhgc3Ym", Networks.livenet);
		 kTras.sign(kPriKey2);

		//console.log(kTras.toString());
		console.log(kTras.inputs[0]._script.toHex());

		console.log(kTras.toString());

		// var utxo0 = 
		// {
		// 		"txId": "912d419e5d262b03332475d5282f42116c9d70f450a691827a79934d9dc72b3d",
		//  		"outputIndex": 0,
		//  		//"address": "mxdRhCiHafagLW5iPAxPMwodrCgP6zL78R",
		//  		"script": "76a9141354786ccbc4f52ccded0a6da3beb2b1c993822f88ac",
		//  		"satoshis": 6806.99948151
		// };

		// var kPriKey : PrivateKey = new PrivateKey("0ad9f46798481316041e2cd23e6f9d34f34acddbfef822d9579434162a2f1750", Networks.testnet);

		// var utxo0 = {
		// 	"txId": "dc55d233e43cc4b0e958161be4170ac72498a82fca03c290f8686ba8e9b423d4",
		// 	"outputIndex": 0,
		// 	"address": "mxdRhCiHafagLW5iPAxPMwodrCgP6zL78R",
		// 	"script": "76a914bbb38177339c839a2321fd0ea82835387a14eb4788ac",
		// 	"satoshis": 10000 };

		// 	var utxo1 = {
		// 	"txId": "b2edb1414157c30400be05decd885a3073ba35aa70c922521a40bb3abe0b64d7",
		// 	"outputIndex": 0,
		// 	"address": "mxdRhCiHafagLW5iPAxPMwodrCgP6zL78R",
		// 	"script": "76a914bbb38177339c839a2321fd0ea82835387a14eb4788ac",
		// 	"satoshis": 100 };

		// var kTra : Transaction = new Transaction();
		// kTra.from(utxo0).from(utxo1);
		// kTra.to("mvDcAc3zs2CPhcDSPyKJZ3Ls1rt33Rxs2y", 50);

		// kTra.sign(kPriKey);

		//console.log(kTra.toString());
		
		//var kB = Buffer.from(hashBA, 0, hashBA.length);
		//console.log("LLLLL: " + hashBA);		

		// var privateKey = new celllink.PrivateKey('L1mu4Si3wU34eAgr4XojZykNYQLM5LWjHiDQX6uqDwtZpxbgC6PS');
		// var utxo = {
		// 	"txId": "115e8f72f39fad874cfab0deed11a80f24f967a84079fb56ddf53ea02e308986",
		// 	"outputIndex": 0,
		// 	"address": "XBtmtPctUv7ChMyaaN2oHxHwL58Nyd94no",
		// 	"script": "76a91447862fe165e6121af80d5dde1ecb478ed170565b88ac",
		// 	"satoshis": 50000
		// };

		// var transaction = new celllink.Transaction()
		// 	.from(utxo)
		// 	.to('XBtmtPctUv7ChMyaaN2oHxHwL58Nyd94no', 15000)
		// 	.sign(privateKey);

		// 	console.log("Transaction: " + transaction.toString());
	}

	private onBtnClick(): void
	{
		//手动控制组件属性
		this.radio.selectedIndex = 1;
		this.clip.index = 8;
		this.tab.selectedIndex = 2;
		this.combobox.selectedIndex = 0;
		this.check.selected = true;
	}

	private onBtn2Click(): void
	{
		//通过赋值可以简单快速修改组件属性
		//赋值有两种方式：
		//简单赋值，比如：progress:0.2，就是更改progress组件的value为2
		//复杂复制，可以通知某个属性，比如：label:{color:"#ff0000",text:"Hello LayaAir"}
		this.box.dataSource = { slider: 50, scroll: 80, progress: 0.2, input: "This is a input", label: { color: "#ff0000", text: "Hello LayaAir" } };

		//list赋值，先获得一个数据源数组
		var arr: Array<any> = [];
		for (var i: number = 0; i < 100; i++)
		{
			arr.push({ label: "item " + i, clip: i % 9 });
		}

		//给list赋值更改list的显示
		this.list.array = arr;

		//还可以自定义list渲染方式，可以打开下面注释看一下效果
		//list.renderHandler = new Handler(this, onListRender);
	}

	private onListRender(item: Laya.Box, index: number): void
	{
		//自定义list的渲染方式
		var label: Label = item.getChildByName("label") as Label;
		if (index % 2)
		{
			label.color = "#ff0000";
		} else
		{
			label.color = "#000000";
		}
	}
}

//程序入口
Laya.init(600, 400);
//激活资源版本控制
Laya.ResourceVersion.enable("version.json", Handler.create(null, beginLoad), Laya.ResourceVersion.FILENAME_VERSION);

function beginLoad()
{
	Laya.loader.load("res/atlas/comp.atlas", Handler.create(null, onLoaded));
}

function onLoaded(): void
{
	//实例UI界面
	var testUI: TestUI = new TestUI();
	Laya.stage.addChild(testUI);
}