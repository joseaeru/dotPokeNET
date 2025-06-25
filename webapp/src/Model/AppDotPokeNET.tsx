import { useState } from "react";
import Resources from './Resource/AppResources.tsx'
import EndPoint from "./EndPoint/AppEndPoints.tsx";


export default function App() {

    const [resourceValue, setResourceValue] = useState<string>("");

    return (
        <>
            <div className="container-fluid">
                <div className="title">
                    <h1 >Wellcome to&nbsp;.PokeNET&nbsp;<small className="lead">This is a simple app to retrieve PokeAPI's EndPoint and test the resources.</small></h1>
                </div>
                <div style={{margin:0, padding:0, paddingBottom:15, borderTop:"2px solid red" }}></div>
                <div className="col-lg-3" style={{ margin: 0, padding: 0 }}>
                    {<Resources onResource={(v) => setResourceValue(v)} />}
                </div>
                <div className="col-lg-9" style={{ margin: 0, padding: 0 }}>
                    {<EndPoint resourceData={resourceValue} />}
                </div>
            </div>
        </>
    );
}

