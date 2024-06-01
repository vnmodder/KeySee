<template>
    <SessionItem :title="'Test tree view'">
        <TreeView :node="treeData" :depth="0" />
    </SessionItem>
</template>

<script setup lang="ts">
import { reactive } from "vue";
import { TreeView ,SessionItem} from '@/components/admin/commons'



const treeData = reactive(
    {
        name: 'Trang chủ',
        path:'sadsadas/sadsa/sadas',
        description: 'có 4 khoa',
        children: [
            {
                name: 'Khoa 1',
                path:'sadsadas/sadsa/sadas',
                description: 'khoa này có 0 lớp'
            },
            {
                name: 'Khoa 2',
                children: [
                    {
                        name: 'Môn học thứ 1',
                        path:'sadsadas/sadsa/sadas',
                        description: 'lớp này có 7 người'
                    },
                    {
                        name: 'Môn học thứ 2',
                        path:'sadsadas/sadsa/sadas',
                        description: 'lớp này có 9 người'
                    },
                ],
                path:'sadsadas/sadsa/sadas',
                description: 'khoa này có 9 lớp'
            },
            {
                name: 'Khoa 3',
                children: [
                    {
                        name: 'Môn học thứ 3',
                    },
                    {
                        name: 'Môn học thứ 4',
                    },
                ]
            },
            {
                name: 'Khoa 4',
            },
        ]
    }
);

</script>