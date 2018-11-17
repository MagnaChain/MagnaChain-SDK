'use strict';

function format(arg) {
  return '\'' + arg
    .replace('{0}', '\' + arguments[0] + \'')
    .replace('{1}', '\' + arguments[1] + \'')
    .replace('{2}', '\' + arguments[2] + \'') + '\'';
}

module.exports = [{
  name: 'RPC',
  message: format('Internal Error on bitcore-rpc Module {0}'),
  errors: [{
    name: 'Unauthorized',
    message: format('Connection rejected: 401 unauthorized')
  }, { 
    name: 'Forbidden',
    message: format('Connection rejected: 403 forbidden')
  }, { 
    name: 'Connection',
    message: format('Could not connect to bitcoin via RPC at host: {0} port: {1}; Error: {2}')
  }]
}];
