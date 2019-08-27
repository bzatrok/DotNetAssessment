app.service("productSrv", function ($http) {
        this.getProductsData = function (search, pagenum) {
            return $http.get('api/Product/GetAllProductsAsync?search=' + search + '&pagenum=' + pagenum)
    },

        this.getProductsDetails = function (id) {
            return $http.get('api/Product/GetAllProductsAsync?id='+id)
        },

            this.getRelatedProduct = function (ProductsIds) {
            return $http.post('api/Product/GetRelatedProducts', ProductsIds)
            }
});
