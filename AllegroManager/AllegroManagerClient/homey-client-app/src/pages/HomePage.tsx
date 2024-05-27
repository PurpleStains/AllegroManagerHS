import './homePage.css'
import Header from '../Header/Header'
import Footer from '../Footer/Footer'
import Body from '../Body/Body'
import Location from './Location'

export default function HomePage() {
    return (
        <div className="home-page">
            <Header />
            <Location />
            <Body />
            <Footer />
        </div>)
}
