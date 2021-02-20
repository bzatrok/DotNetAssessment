<template>
    <div v-if="show" class="error">
      <p>Something went wrong!</p>
    </div>
</template>

<script>
export default {
    props: ["show"]
}
</script>

<style scoped>
  .error {
    background-color: red;
    color: white;
    padding: 10px;
    border-radius: 5px;
    margin-bottom: 20px ;
  }

  .error > p {
    margin: 0;
  }
</style>