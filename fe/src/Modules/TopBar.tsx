import menu from '../assets/menu.png'
import profile from '../assets/profile.png'

function TopBar() {
    
    return (
        <>
            <div className="flex flex-row py-2 my-2 w-full justify-between">
                <img src={menu} className='w-12 h-10' />
                <span className='font-bold text-3xl dark:text-sky-800 '>biljou</span>
                <img src={profile} className='w-12 h-10' />
            </div>
        </>
    )
}

export default TopBar