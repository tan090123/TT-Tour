<template lang="">
    <div v-if="isLogin">
        <AdNav/>
    <section id="content">
        <AdHeader :isLogin="isLogin"/>
        <router-view></router-view>
    </section>
    </div>
    <div v-else class="login-message">
        <div>
            <p>Vui lòng 
                <router-link class="nav-link" target="_blank" :to="{ name: 'login_component' }">Đăng nhập</router-link>
             để truy cập vào trang quản trị này 🤓😎.</p>
        </div>
</div>

</template>
<script>
import AdHeader from '@/components/AdHeader.vue';
import AdNav from '@/components/AdNav.vue';
import '@/assets/scss/_admin.scss';

export default {
    name: 'Admin-layout',
    components: {
        AdNav,
        AdHeader
    },
    data() {
        return {
            isLogin: false,
        }
    },
    methods: {
        checkLogin() {
            const adminEmail = localStorage.getItem('adminEmail');
            if (adminEmail) {
                this.isLogin = true;
                console.log(this.isLogin);
            } else {
                this.isLogin = false;
            }
        },

    },
    mounted() {
        this.checkLogin();

        // // APEXCHART
        // var options = {
        //     series: [{
        //         name: 'series1',
        //         data: [31, 40, 28, 51, 42, 109, 100]
        //     }, {
        //         name: 'series2',
        //         data: [11, 32, 45, 32, 34, 52, 41]
        //     }],
        //     chart: {
        //         height: 350,
        //         type: 'area'
        //     },
        //     dataLabels: {
        //         enabled: false
        //     },
        //     stroke: {
        //         curve: 'smooth'
        //     },
        //     xaxis: {
        //         type: 'datetime',
        //         categories: ["2018-09-19T00:00:00.000Z", "2018-09-19T01:30:00.000Z", "2018-09-19T02:30:00.000Z", "2018-09-19T03:30:00.000Z", "2018-09-19T04:30:00.000Z", "2018-09-19T05:30:00.000Z", "2018-09-19T06:30:00.000Z"]
        //     },
        //     tooltip: {
        //         x: {
        //             format: 'dd/MM/yy HH:mm'
        //         },
        //     },
        // };

        // // eslint-disable-next-line no-undef
        // var chart = new ApexCharts(document.querySelector("#chart"), options);
        // chart.render();
    }

}
</script>
<style lang="scss" scoped>
.login-message {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
    background-color: #ef70fb;

    div {
        background-color: rgb(151, 32, 123);
    padding: 1.5rem;
    text-align: center;
    font-size: 1.6rem;
    color: #fff;
    box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
    border-radius: 4px;
    }

    a {
        display: inline-block;
        color: #fff;
        font-weight: bold;
        margin: 0 -5px;
    }
}
</style>