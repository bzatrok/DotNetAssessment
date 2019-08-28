app.controller("ProductDetailsCtrl", [
    '$scope',
    'productSrv',
    '$state',
    function ($scope, productSrv, $state) {

        getProductData();

        function getProductData() {
            var id = $state.params.id;

            var servCall = productSrv.getProductsDetails(id);
            servCall.then(function (response) {
                $scope.Product = response.data.Data;
                getRelatedProducts($scope.Product.frequentlyPurchasedWith)
                console.log(response);

            })
        }


        function getRelatedProducts(ProductsIds) {
            var servCall = productSrv.getRelatedProduct(ProductsIds);
            servCall.then(function (response) {
                $scope.RelatedProducts = response.data.Data;
                console.log($scope.RelatedProducts);

            })
        }
    
    
    }

    
]);