<template>
    <nuxt-link :to="`/products/${product.id}`" style="text-decoration: none; color: inherit;">
        <div class="row">
            <v-img 
                :src="product.thumbnailImage" 
                max-height="70px"
                height="70px"
                max-width="70px"
                width="70px"
                contain
                :alt="product.name"/>
            <p>{{truncate(product.name, 50)}}</p>
            <p>{{`$${product.price}`}}</p>
        </div>
    </nuxt-link>
</template>

<script>
export default {
    props: ["product"],
    methods: {
        truncate(str, n){
            return (str.length > n) ? str.substr(0, n-1) + '...' : str;
        }
    }
}
</script>

<style scoped>
    .row{
        background: whitesmoke;
        border: 1px solid rgba(200, 200, 200, 0.7);
        border-radius: 8px;
        display: flex;
        justify-content: space-around;
        align-items: center;
        min-height: 90px;
        margin: 25px 0;
        cursor: pointer;
        display: grid;
        grid-template-columns: 2fr 6fr 2fr;
        justify-items: center;
        align-items: center;
    }

    .row p {
        padding: 0;
        margin: 0;
    }
</style>