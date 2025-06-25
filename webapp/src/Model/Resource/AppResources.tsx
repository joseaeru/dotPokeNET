import { useEffect, useState } from "react";
import type ResourcesDTO from "./ResourcesDTO";


type Props = {
    onResource: (valor: string) => void;
};

export default function AppResources({ onResource }: Props) {

    const [activeButton, setActiveButton] = useState<number>(); // State to track the active button
    const [getResources, setResources] = useState<ResourcesDTO>();

    const baseUrl = import.meta.env.VITE_DOTPOKENETBASEURL;
    if (!baseUrl) {
        throw new Error("API URL is not defined.");
    }

    console.log(`Conecting to ${baseUrl}/api/Resource/All`);

    useEffect(() => {
        fetch(`${baseUrl}/api/Resource/All`)
            .then((response) => response.json().then((data) => setResources(data)))
            .catch((error) => {
                console.error("Error fetching resources:", error);
                setResources(undefined);
            });

        document.getElementById("paramInput")?.focus(); // Focus input after component mounts
    }, [baseUrl]);

    // Function to handle button click and pass the resource code to the parent component
    const onClickHandler = (id: number): void => {
        setActiveButton(id);
    };

    return (
        <>
            <h4>Resources</h4>

            {getResources ? (
                <div className="col-lg-12" style={{ margin: 0, padding: 0, }}>
                    <p className="text-muted">Click on a resource to see its details.</p>
                    <div className="col-lg-12" style={{ margin: 0, padding: 0, maxHeight: "70vh", overflowY: "auto" }}>
                        <div className="btn-block btn-group-vertical" >
                            {getResources.resources.map(r => (
                                <button
                                    type="button"
                                    id={`${r.resourceCode}`}
                                    value={`${r.resourceName}`}
                                    style={{ textWrap: 'nowrap' }}
                                    onClick={() => onResource(`${r.resourceName}`)}
                                    onClickCapture={() => onClickHandler(r.resourceCode)}
                                    className={`${"btn btn-danger"} ${activeButton === r.resourceCode ? 'active' : ''}`}
                                >
                                    {`${r.resourceName.replace(/_/g, " ")}`}
                                </button>
                            ))}
                        </div>
                    </div>
                </div>
            ) : (
                <div className="progress">
                    <div
                        className="progress-bar progress-bar-striped active"
                        role="progressbar"
                        aria-valuenow={100}
                        aria-valuemin={0}
                        aria-valuemax={100}
                        style={{ width: "100%" }}
                    >
                        <span>Loading Resources...</span>
                    </div>
                </div>
            )}
        </>
    );
}

