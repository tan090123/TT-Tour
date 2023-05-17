<template>
  <!-- <img alt="Vue logo" src="./assets/logo.png">
  <HelloWorld msg="Welcome to Your Vue.js App"/> -->
  <h3></h3>
  <Header/>
    <TourMain/>
    <TourCarousel/>
    <TourCard/>
  <Footer/>
</template>

<script>
import Header from './components/Header.vue';
import TourMain from './Views/Page/TourMain.vue';
import Footer from './components/Footer.vue';
import TourCarousel from './Views/Page/TourCarousel.vue';
import TourCard from './Views/Page/TourCard.vue';

export default {
  name: 'App',
  components: {
    Header,
    TourMain,
    TourCarousel,
    TourCard,
    Footer,

  }
}
</script>

<!-- <style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style> -->
