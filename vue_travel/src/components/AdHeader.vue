<template>
    <header class="app-header">
        <div class="container-fluid">
            <div class="row">
                <div class="col-3 logo text-start">
                    <img src="@/../public/images/logo/favicon.png" alt="Logo">
                    <span>Vietravel</span>
                </div>
                <div class="col-9 text">
                    <p>Admin</p>
                </div>
            </div>
        </div>
    </header>
</template>
<script>
export default {

}
</script>
<style lang="scss" scoped>
header {
    padding: 1.5rem;
    background-color: #6c5ce7;
}

.row {
    --bs-gutter-x: 0 !important;
}

.logo {
    display: flex;
    justify-content: flex-start;
    align-items: center;
    color: #fff;

    img {
        width: 4rem;
        object-fit: cover;
        margin-right: 1.5rem;
    }
}

.text {
    display: flex;
    justify-content: flex-end;
    align-items: center;
    text-align: end;
    padding-right: 1.5rem;
    color: #fff;
}
</style>