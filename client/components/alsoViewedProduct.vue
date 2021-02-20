<template>
    <nuxt-link :to="`/products/${id}`" class="navigation">
        <v-card class="mb-2 rounded-lg" tile height="100%">
            <v-row align="start" class="maxHeight">
                <v-col class="shrink" align-self="center" >
                    <img :src="imageUrl" class="productImage">
                </v-col>
                <v-col>
                    <v-card-subtitle>{{name}}</v-card-subtitle>
                    <v-card-text>${{price}}</v-card-text>
                </v-col>
            </v-row>
        </v-card>
    </nuxt-link>
</template>

<script>
export default {
    props: ["id", "name", "price", "imageUrl"]
}
</script>

<style scoped>
    .navigation {
        text-decoration: none;
    }

    .productImage {
        max-width: 80px;
        max-height: 200px;
        object-fit: contain;
        margin-left: 30px;
    }

    .maxHeight {
        height: 100%;
    }
</style>