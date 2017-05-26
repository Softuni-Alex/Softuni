(function () {

    // Create your own kinvey application

    let baseUrl = "https://baas.kinvey.com";
    let appKey = "kid_BJIVrATS";
    let appSecret = "f4d7388632fc4f22a44e6b1426da6c2e";
    var _guestCredentials = "25a1c125-f0a2-4dfc-8fb1-088d84c245b0.eZdKlGlbIr+266WOimwdyNNU1q6RptpA5eRhS4IaBfM=";

    let authService = new AuthorizationService(baseUrl,appKey,appSecret,_guestCredentials)
    authService.initAuthorizationType("Kinvey")
    let requester = new Requester(authService)

    let selector = ".wrapper";
    let mainContentSelector = ".main-content";

    let homeView = new HomeView(selector,mainContentSelector)
    homeView.showGuestPage()
    let homeController = new HomeController(homeView)

    let postView = new PostView(selector,mainContentSelector)
    let postController = new PostController(postView)

    let userView = new UserView(selector,mainContentSelector)
    let userController = new UserController(userView)

    initEventServices();

    onRoute("#/", function () {
        // Check if user is logged in and if its not show the guest page, otherwise show the user page...
    });

    onRoute("#/post-:id", function () {
        // Create a redirect to one of the recent posts...
    });

    onRoute("#/login", function () {
        // Show the login page...
    });

    onRoute("#/register", function () {
        // Show the register page...
    });

    onRoute("#/logout", function () {
        // Logout the current user...
    });

    onRoute('#/posts/create', function () {
        // Show the new post page...
    });

    bindEventHandler('login', function (ev, data) {
        // Login the user...
    });

    bindEventHandler('register', function (ev, data) {
        // Register a new user...
    });

    bindEventHandler('createPost', function (ev, data) {
        // Create a new post...
    });

    run('#/');
})();
