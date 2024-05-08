<template>
    <div id="wrapper">
        <LeftMenu />
        <div id="content-wrapper" class="d-flex flex-column">
            <!-- Main Content -->
            <div id="content">
                <div class="container-fluid">
                    <Topbar/>
                    <router-view />
                </div>
            </div>
            <PageFooter/>
        </div>
    </div>
</template>
<script setup lang="ts">
import { LeftMenu , PageFooter, Topbar} from '@/components/admin'
</script>
