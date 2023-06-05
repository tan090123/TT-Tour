<template lang="">
    <Header />
    <router-view></router-view>
    <Footer />
</template>
<script>
import Header from '../components/TheHeader.vue';
import Footer from '../components/TheFooter.vue';
export default {
    name: 'Home-layout',
    components: {
        Header,
        Footer,
    }
}
</script>