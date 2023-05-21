<template lang="">
    <!-- ========== Start Register ========== -->
    <main class="login">
        <div class="container">
            <div class="row form-wrap">

                <div class="login-title text-center mb-4">
                    <h5>Chào mừng Quý khách đến với</h5>
                    <h2 class="fw-bold m-0">Vietravel</h2>
                </div>

                <div class="login-form bg-white">
                    <h2 class="text-center">Đăng ký</h2>
                    <form action="#">
                        <div class="mb-3">
                            <label for="name" class="form-label fw-bold">Họ và tên</label>
                            <span class="text-danger">*</span>
                            <input class="fomr-control" type="text" name="name" id="name" placeholder="Nhập họ và tên">
                        </div>
                        <div class="mb-3">
                            <label for="email" class="form-label fw-bold">Số điện thoại hoặc email</label>
                            <span class="text-danger">*</span>
                            <input class="fomr-control" type="text" name="email" id="email" placeholder="Tài khoản">
                        </div>

                        <div class="mb-3">
                            <label for="email" class="form-label fw-bold">Mật khẩu</label>
                            <span class="text-danger">*</span>
                            <input class="fomr-control" type="text" name="email" id="email" placeholder="Mật khẩu">
                        </div>
                        <div class="mb-3">
                            <label for="email" class="form-label fw-bold">Xác nhận mật khẩu</label>
                            <span class="text-danger">*</span>
                            <input class="fomr-control" type="text" name="email" id="email"
                                placeholder="Xác nhận mật khẩu">
                        </div>

                        <button class="btn-primary w-100 fw-bold">
                            Đăng ký <i class="fas fa-sign-in-alt" aria-hidden="true"></i>
                        </button>
                        <div class="form-or">
                            <p>Hoặc</p>
                        </div>
                        <div class="form-on">
                            <div class="btn-facebook" id="btn_facebook">
                                <a href="!#">
                                    <i class="fab fa-facebook" aria-hidden="true"></i>
                                    <span>Tiếp tục với Facebook</span>
                                </a>
                            </div>

                            <div class="btn-google" id="btn_google">
                                <a href="!#">
                                    <i class="fab fa-google-plus-g"></i>
                                    <span>Tiếp tục với Google</span>
                                </a>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </main>
    <!-- ========== End Register ========== -->
</template>
<script>
export default {
    name: "register-component",
}
</script>
<style lang="scss">
@import "@/assets/scss/_login.scss";
</style>