const controllers = require('../controllers')
const restrictedPages = require('./auth')

module.exports = app => {
    app.get('/', controllers.home.index)

    //User routes
    app.get('/login', controllers.user.loginGet)
    app.get('/register', controllers.user.registerGet)
    app.post('/login', controllers.user.loginPost)
    app.post('/register', controllers.user.registerPost)
    app.post('/logout', controllers.user.logout)

    //Orders
    app.get('/order-status', controllers.order.getOrderStatusView)
    app.get('/create-product', controllers.order.getCreateProductView)
    app.post('/create-product', controllers.order.postCreateProduct)
    app.get('/customize-order/:id', controllers.order.getCustomizeOrder)
    //  app.post('/addHotel', controllers.hotel.addHotel)
    //
    // app.get('/details',controllers.hotel.getDetails)
    // app.get('/like/:id',controllers.hotel.likeDislike)
    //
    // //Comment
    // app.post('/comment/:id',controllers.comment.addComment)
    //
    // app.get('/addCategories',controllers.categories.getView)
    // app.post('/addCategories',controllers.categories.createCat)
    //
    // //List
    // app.get('/list',controllers.hotel.getList)
    //
    //
    // app.get('/getDetails/:id',controllers.user.getDetails)
    // app.get('/banUser/:id',restrictedPages.hasRole('Admin'),controllers.user.banUser)

    app.all('*', (req, res) => {
        res.status(404)
        res.send('404 Not Found')
        res.end()
    })
}