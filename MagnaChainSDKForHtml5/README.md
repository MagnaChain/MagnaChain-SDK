# SDK Content  

The SDK includes source code (magnachain.js, bn.js and other js files) in the src directory, and the interface declaration file magnachain.t.ts. With the SDK, developers can quickly and easily access blockchain support in Html5 projects.  

# SDK important class description
1. Networks：Blockchain network type  
2. PublicKey：Public key class  
3. Address：Blockchain address  
4. PrivateKey：Private key class  
5. HDPrivateKey：Layered address private key based on BIP32  
6. HDPublicKey：BIP32-based public layer to determine the address public key  
7. Script：Script  
8. Signature：Class for signing  
9. Output, Input：Input and output objects in the transaction  
10. Transaction：Trading partners

# Instructions  

1. Create, import private key, get address  

```javascript
    // Create
    var kPirKey : PrivateKey = new PrivateKey();
        
    // import
    var kPriKey2 : PrivateKey = PrivateKey.fromWIF("XBtmtPctUv7ChMyaaN2oHxHwL58Nyd94no");
        
    // pubKey
    var kPubKey : PublicKey = kPirKey.toPublicKey();
        
    // address
    var strAddr : string = kPirKey.toAddress();
    var strAddr2 : string = kPubKey.toAddress();
```
2. BIP32 hierarchical address 

```javascript
    // Create HD private key
    var kHDKey1 : HDPrivateKey = new HDPrivateKey();
    
    // Create an HD private key from the mnemonic
    var kHDKey2 : HDPrivateKey = HDPrivateKey.fromMnemonicWord("magna chain is good");
    
    // Get the original private key
    var kPriKey : PrivateKey = kHDKey1.privateKey;
    
    // Create a sub-private key
     var kHDChildKey : HDPrivateKey = kHDKey1.deriveChild(1);
```

3. Trading  

    The current version of the Html5 SDK does not provide RPC functionality. Developers are required to first use the RPC command [precallcontract] to get to the hex string of the transaction, then locally sign it with the private key, and then broadcast it to the blockchain network via RPC  
```javascript
    //precallcontract rpc result
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

        var kTras = new magnachain.Transaction(rpcRet.txhex);
        kTras.setOutputsFromCoins(rpcRet.coins);

        var kPriKey1 = new PrivateKey("L1amKPbuEpYwqU2uVRb34i2oUAa328RvNaEoKrCqgdEPLgV6MDcz", Networks.livenet);    
        kTras.sign(kPriKey1);
```  

    After the signature is completed, broadcast to the blockchain network using the RPC command [sendrawtransaction].  






