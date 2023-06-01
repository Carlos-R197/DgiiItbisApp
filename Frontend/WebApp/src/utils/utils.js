export default function formatIdCard(rncIdCard) {
    if (rncIdCard.length === 11) {
        return rncIdCard.substring(0, 3) + "-" + rncIdCard.substring(3, 10) + "-" + rncIdCard.charAt(10)
    } else {
        return rncIdCard
    }
}