

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import HelloWorld from "@/components/HelloWorld.vue"; // @ is an alias to /src
import { ProductResponse, Product } from "@/models/Products";
import ProductsContainer from "@/components/ProductsContainer.vue";
import ProductCard from "@/components/ProductCard.vue";
@Component({
  components: {
    ProductsContainer,
    ProductCard
  }
})
export default class Home extends Vue {
  productList: Array<Product>;
  searchInput: string = "";
  currentPage: number;
  resultHeader: string;
  scollStarted:boolean;
  constructor() {
    super();

    this.resultHeader = "products on sale";
    this.productList = new Array<Product>();
    this.currentPage = 1;
    this.scollStarted=false;
    this.getProducts();

    window.addEventListener("scroll", () => this.update(), false);
  }
  update(): Promise<boolean> {
    return new Promise<boolean>(resolve => {
      var bottom = this.bottomVisible();
      if (bottom && !this.scollStarted) {
        this.currentPage++;
        this.scollStarted=true;
        if (this.currentPage < 25) {
          this.getData(this.searchInput, this.currentPage, 20)
            .then((myJson: ProductResponse) => {
              if (myJson && myJson.products) {
                myJson.products.forEach(element => {
                  this.productList.push(element);
                });
                this.scollStarted=false;
              }

            })
            .catch(re => {
              this.scollStarted=false;
              console.log("Catch", re);
            });
        }
      }
      resolve(true);
    });
  }
  bottomVisible(): Promise<boolean> {
    return new Promise<boolean>(resolve => {
      const scrollY = window.scrollY;
      const visible = document.documentElement.clientHeight;
      const pageHeight = document.documentElement.scrollHeight;
      const bottomOfPage = visible + scrollY >= pageHeight;
      resolve(bottomOfPage || pageHeight < visible);
    });
  }
  searchProducts() {
    this.productList = [];
    this.getProducts();
  }
  getProducts() {
    this.getData(this.searchInput, this.currentPage, 20)
      .then((myJson: ProductResponse) => {
        if (myJson && myJson.products) {
          myJson.products.forEach(element => {
            this.productList.push(element);
          });
        }
      })
      .catch(re => {
        console.log("Catch", re);
      });
  }

  getData(
    search: string,
    pageNumber: number,
    size: number
  ): Promise<ProductResponse> {
    var search = this.searchInput;
    var page = pageNumber === undefined ? 1 : pageNumber;
    if (search && search != "") {
      search = `((search=${search}))`;
    } else {
      search = "(onSale=true)";
    }
    return fetch(
      `https://localhost:44387/api/products?search=${search}&page=${page}`
    )
      .then(response => {
        return response.json();
      })
      .then(res => {
        return JSON.parse(res.Response);
      })
      .then((myJson: ProductResponse) => {
        if (this.searchInput && this.searchInput != "") {
          this.resultHeader = "Results";
        }

        return new Promise<ProductResponse>(resolve => {
          resolve(myJson);
        });
      })
      .catch(re => {
        return new Promise<ProductResponse>(resolve => {
          resolve(re);
        });
      })
      
  }
}
</script>

<template>
  <div class="header">
    <input
      placeholder="What you looking for.."
      v-model="searchInput"
      type="text"
      v-on:keyup.enter="searchProducts"
    />
    <button @click="searchProducts">Search</button>
    <h1 class="alert">{{resultHeader}}</h1>
    <ProductsContainer v-bind:products="productList" />
  </div>
</template>