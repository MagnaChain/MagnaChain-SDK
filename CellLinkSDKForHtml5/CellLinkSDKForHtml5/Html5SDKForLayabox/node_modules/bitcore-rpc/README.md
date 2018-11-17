bitcoind JSON-RPC for bitcore
=======

[![NPM Package](https://img.shields.io/npm/v/bitcore-rpc.svg?style=flat-square)](https://www.npmjs.org/package/bitcore-rpc)
[![Build Status](https://img.shields.io/travis/bitpay/bitcore-rpc.svg?branch=master&style=flat-square)](https://travis-ci.org/bitpay/bitcore-rpc)
[![Coverage Status](https://img.shields.io/coveralls/bitpay/bitcore-rpc.svg)](https://coveralls.io/r/bitpay/bitcore-rpc?branch=master)

bitcore-rpc adds support to connect to bitcoind's RPC interface

See [the main bitcore repo](https://github.com/bitpay/bitcore) or the [bitcore guide on RPC](http://bitcore.io/guide/jsonrpc.html) for more information.

## Getting Started

In order to connect to an instance of bitcoind, you'll need to have set a username and password on that instance. See [running bitcoin](https://en.bitcoin.it/wiki/Running_Bitcoin) for information on how to configure bitcoin.conf.

```sh
npm install bitcore-rpc
bower install bitcore-rpc
```

Take a look at the [JSON-RPC API reference](https://en.bitcoin.it/wiki/API_reference_%28JSON-RPC%29) on the main bitcoin wiki.

You can then make requests to that instance. For example, you could do: 
```javascript
var RPC = require('bitcore-rpc');
var blockHash = '0000000000000000045d581af7fa3b6110266ece8131424d95bf490af828be1c';

var client = new RPC('username', 'password');

client.getBlock(blockHash, function(err, block) {
  // do something with the block
});
```

## Contributing

See [CONTRIBUTING.md](https://github.com/bitpay/bitcore) on the main bitcore repo for information about how to contribute.

## License

Code released under [the MIT license](https://github.com/bitpay/bitcore/blob/master/LICENSE).

Copyright 2013-2015 BitPay, Inc. Bitcore is a trademark maintained by BitPay, Inc.
