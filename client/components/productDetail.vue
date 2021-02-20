<template>
    <div v-if="show" class="productDetail__container">
        <h4>{{name}}:</h4>
        <p :class="{crossed: cross}">
            {{`${showDollar ? '$ ' : '' }${value}`}}
        </p>
    </div>
</template>

<script>
export default {
    props: ['name', 'value', 'show', 'cross', 'showDollar']
}
</script>

<style scoped>
    .productDetail__container {
        box-sizing: border-box;
        margin: 10px;
    }

    .crossed {
        text-decoration: line-through;
    }
</style>