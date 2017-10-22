module.exports = {
    development: {
        port: process.env.PORT || 4567,
        dbPath: 'mongodb://localhost:27017/doner-place-db'
    },
    production: {}
}