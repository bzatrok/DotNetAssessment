
function config($stateProvider, $urlRouterProvider, $ocLazyLoadProvider) {//, $compileProvider) {

    $urlRouterProvider.otherwise("/home");

    $ocLazyLoadProvider.config({
        // Set to true if you want to see what and when is dynamically loaded
        debug: false
    });

    $stateProvider

        .state('home', {          
            url: '/home',
            templateUrl: '/App/Product/Products.html'
        })
        .state('ProductDetails', {
            url: '/ProductDetails/:id',
            templateUrl: '/App/Product/ProductDetails.html'
        });

}
app.config(config);