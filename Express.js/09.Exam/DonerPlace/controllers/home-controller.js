const Product = require('mongoose').model('Product')

module.exports = {
    index: (req, res) => {
        Product.find({}).sort('category').then(products => {
            res.render('home/home', {products})
        })
    }
}
