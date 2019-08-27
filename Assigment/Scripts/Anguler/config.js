
function config($stateProvider, $urlRouterProvider, $ocLazyLoadProvider) {//, $compileProvider) {

    $urlRouterProvider.otherwise("/home");

    $ocLazyLoadProvider.config({
        // Set to true if you want to see what and when is dynamically loaded
        debug: false
    });

    $stateProvider

        .state('home', {          
            url: '/home',
            templateUrl: '/App/Products.html'
        })
        .state('ProductDetails', {
            url: '/ProductDetails/:id',
            templateUrl: '/App/ProductDetails.html'
        });

        //.state('index', {
        //    abstract: true,
        //    url: "/index",
        //    template:"<h1>Hello</h1>"// "Views/Product/ProductDetails.html",
        //})
        //.state('index.productDetails', {
          
        //    url: "/productDetails",
        //    templateUrl: "'/views/Home/ProductDetils.html'",
        //});
}
app.config(config);