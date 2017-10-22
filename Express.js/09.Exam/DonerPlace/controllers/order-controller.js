const Product = require('mongoose').model('Product')

module.exports = {
    getOrderStatusView: (req, res) => {
        res.render('orders/order-status')
    },
    getCreateProductView: (req, res) => {
        res.render('orders/create-product')
    },
    postCreateProduct: (req, res) => {
        const product = req.body

        let stringToppings = product.toppings

        let toppingsArr = stringToppings.split(",")
        const productObj = {
            category: product.category,
            imageUrl: product.imageUrl,
            size: product.size,
            toppings: toppingsArr
        }
        Product.create(productObj)
            .then(p => {
                p.save()
                res.redirect("/")
            }).catch(function (e) {
            console.log(e)
        })
    },
    getCustomizeOrder: (req, res) => {
        let productId = req.path.split('/')[2]

        if (!res.locals.currentUser) {
            res.render('users/login')
        }
        else {
            Product.find({_id: productId})
                .then(product => {
                    res.render('orders/customize-order', {product})
                })
        }
    }
}
