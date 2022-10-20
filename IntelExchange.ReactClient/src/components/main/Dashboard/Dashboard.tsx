import './Dashboard.scss';
import LoadingSign from '../../shared/LoadingSign/LoadingSign';

type DashboardProps = {};

const Dashboard: React.FC<DashboardProps> = ({ }) => {

    return (
        <div className="dashboard-component">
            <h2>Dashboard Page</h2>
            <LoadingSign />
        </div>
        );
}

export default Dashboard;