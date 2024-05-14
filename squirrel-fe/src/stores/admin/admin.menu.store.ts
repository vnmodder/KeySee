import { menuItems } from '@/views/admin/admin.menu';
import { defineStore } from 'pinia';

export const adminMenuStore =  defineStore({
    id: 'admin-menu',
    state: () => ({
        menuItems : menuItems
    }),
    actions: {
        getMenuItems (){
            return menuItems;
        },
        updateMenuState(path:string){
            menuItems.forEach(x=>{
                x.isAtive = path==x.href
            });
        }
    }
});