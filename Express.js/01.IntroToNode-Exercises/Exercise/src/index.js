let Storage = require('./storage')

let storage = new Storage()

storage.put('first', 'firstValue')
storage.save()
storage.load()
