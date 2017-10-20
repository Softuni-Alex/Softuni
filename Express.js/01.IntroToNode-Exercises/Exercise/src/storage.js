let fs = require('fs')
let util = require('util')
let store = {}

class Storage {
    put(key, value) {
        if (typeof key !== 'string') {
            throw new Error('The key cannot be non-string');
        }
        if (store.hasOwnProperty(key)) {
            throw new Error('The key is already present in the store.');
        }
        else {
            store[key] = value
        }
    }

    get(key) {
        if (typeof key !== 'string') {
            throw new Error('The key cannot be non-string');
        }
        if (!store.hasOwnProperty(key)) {
            throw new Error('The key does not persist in the store.');
        } else {
            return store[key]
        }
    }

    getAll() {
        if (Object.keys(store).length === 0) {
            return 'There are no items in the storage'
        } else {
            return store
        }
    }

    update(key, newValue) {
        if (typeof key !== 'string') {
            throw new Error('The key cannot be non-string');
        }
        if (!store.hasOwnProperty(key)) {
            throw new Error('The key does not persist in the store.');
        } else {
            store[key] = newValue
        }
    }

    deleteFromStorage(key) {
        if (typeof key !== 'string') {
            throw new Error('The key cannot be non-string');
        }
        if (!store.hasOwnProperty(key)) {
            throw new Error('The key does not persist in the store.');
        } else {
            delete store[key]
        }
    }

    clear() {
        store = {}
    }

    save() {
        fs.writeFile('./storage.json', JSON.stringify(store), 'utf-8', (err) => {
            if (err) {
                console.log(err.message)
                return
            }
        })
    }

    load() {
        if (fs.existsSync('./storage.json')) {
            fs.readFile('./storage.json', 'UTF-8', (err, data) => {
                if (err) {
                    console.log(err.message)
                    return
                }  

                console.log(data)
            })
        }
    }
}

module.exports = Storage