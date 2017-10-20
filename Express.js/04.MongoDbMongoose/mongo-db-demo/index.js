const mongoose = require('mongoose')
let connectionString = 'mongodb://localhost:27017/unidb'
let errorHandler = err => {
  console.log(`Error: ${err['message']}`)
}
mongoose.Promise = global.Promise
const createDemo = require('./create-demo')
const quieryingDemo = require('./querying-demo')
const updateDemo = require('./update-demo')
const removeDemo = require('./remove-demo')

mongoose.connect(connectionString, err => {
  if (err) {
    errorHandler(err)
    return
  }

  createDemo()
  quieryingDemo()
  updateDemo()
  removeDemo()
})
