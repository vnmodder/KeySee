<template>
    <SessionItem :label="'Category'" >
        <InputItem :labelValue ="'Test input 1'"/>
        <InputItem :labelValue ="'Test input 2'"/>
        <InputItem :labelValue ="'Test input 3'"/>
    </SessionItem>
</template>

<script setup  lang="ts">
import {SessionItem, InputItem} from '@/components/admin/commons'

</script>