<template lang="">
   <!-- SIDEBAR -->
	<section id="sidebar">
		<a href="/admin" class="brand"><i class='bx bxs-smile icon'></i> AdminTravel</a>
		<ul class="side-menu">
			<li>
				<router-link class="active" :to="{ name: 'HomeAdmin' }">
					<i class='bx bxs-dashboard icon'></i>Dashboard
				</router-link>
				<!-- <a href="#" class="active"><i class='bx bxs-dashboard icon'></i>Dashboard</a> -->
			</li>
			<li class="divider" data-text="main">Main</li>
			<li>
				<a href="#"><i class='bx bxs-briefcase icon'></i>Quản lý tour<i
						class='bx bx-chevron-right icon-right'></i></a>
				<ul class="side-dropdown">
					<li>
						<router-link :to="{ name: 'tour-admin' }">Danh sách Tour</router-link>
					</li>
					<li><a href="#">Chi tiết tour</a></li>
					<li><a href="#">Hình ảnh tour</a></li>
				</ul>
			</li>
			<li>
				<a href="#"><i class='bx bxs-briefcase icon'></i>Quản lý user<i
						class='bx bx-chevron-right icon-right'></i></a>
				<ul class="side-dropdown">
					<li>
						<router-link :to="{ name: 'user-admin' }">Danh sách user</router-link>
					</li>
					<li><a href="#">Badges</a></li>
					<li><a href="#">Breadcrumbs</a></li>
					<li><a href="#">Button</a></li>
				</ul>
			</li>
			<li>
				<a href="#"><i class='bx bxs-briefcase icon'></i>Quản lý order<i
						class='bx bx-chevron-right icon-right'></i></a>
				<ul class="side-dropdown">
					<li>
						<router-link :to="{ name: '' }">Danh sách order</router-link>
					</li>
					<li><a href="#">Badges</a></li>
					<li><a href="#">Breadcrumbs</a></li>
					<li><a href="#">Button</a></li>
				</ul>
			</li>
			<!-- <li><a href="#"><i class='bx bxs-chart icon'></i> Charts</a></li>
			<li><a href="#"><i class='bx bxs-widget icon'></i> Widgets</a></li>
			<li class="divider" data-text="table and forms">Table and forms</li>
			<li><a href="#"><i class='bx bx-table icon'></i> Tables</a></li>
			<li>
				<a href="#"><i class='bx bxs-notepad icon'></i> Forms <i class='bx bx-chevron-right icon-right'></i></a>
				<ul class="side-dropdown">
					<li><a href="#">Basic</a></li>
					<li><a href="#">Select</a></li>
					<li><a href="#">Checkbox</a></li>
					<li><a href="#">Radio</a></li>
				</ul>
			</li> -->
		</ul>
	</section>
	<!-- SIDEBAR -->
</template>
<script>
export default {
	methods: {
		navigate(route) {
			this.$router.push(route).then(() => {
				window.location.reload();
			});
		}
	}

}
</script>
<style lang="">
    
</style>