<template lang="">
    <Nav/>
    <router-view></router-view>
</template>
<script>
import Nav from '@/components/AdHeader.vue'
export default {
    name: 'Admin-layout',
    components: {
        Nav
    }

}
</script>
<style lang="">
    
</style>