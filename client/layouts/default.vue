<template>
  <v-app >
    <v-main class="main">
      <div class="container">
        <nuxt />
      </div>
    </v-main>
    <!-- <v-main>
      <v-container class="grey lighten-4 fill-height">
        <nuxt />
      </v-container>
    </v-main> -->
  </v-app>
</template>

<script>
export default {
  data () {
    return {
      clipped: false,
      drawer: false,
      fixed: false,
      items: [
        {
          icon: 'mdi-apps',
          title: 'Welcome',
          to: '/'
        },
        {
          icon: 'mdi-chart-bubble',
          title: 'Inspire',
          to: '/inspire'
        }
      ],
      miniVariant: false,
      right: true,
      rightDrawer: false,
      title: 'Vuetify.js'
    }
  }
}
</script>

<style scoped>
  .main{
    background: lightgray;
  }

  .container {
    box-sizing: border-box;
    height: 100vh;
    margin: 0 auto;
    padding: 10px 30px;
    max-width: 900px;
    width: 100%;
    background: #e7e7e7;
    overflow: scroll;
    -ms-overflow-style: none;
    scrollbar-width: none;
  }

  .container::-webkit-scrollbar {
    display: none;
  }
</style>