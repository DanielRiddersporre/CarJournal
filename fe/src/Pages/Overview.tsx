import { Outlet, Link } from "react-router-dom";

function Overview () {
    return (
        <>
            <div className="text-center py-10">
                <p>Detta är översikten</p>
                <Link to="/dataEntry">Data Entry</Link>
            </div>
        </>
    )
}

export default Overview;
