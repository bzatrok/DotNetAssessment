<template>
  <div>
    <div class="site-navbar">
      <router-link to="/" >
        <img src="./assets/logo.jpg" alt width="130" />
      </router-link>
      <nav>
        <ul>
          <li>Home</li>
          <li>Services</li>
          <li>Products</li>
          <li>Clients</li>
        </ul>
      </nav>
    </div>

    <router-view :key="$route.path" />
  </div>
</template>
<style>
</style>

